using WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository;

namespace WMS.View.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IActionResult> Item(string sortField = "ItemId", string sortDirection = "asc", int pageNumber = 1, int pageSize = 10)
        {
            var items = await _itemRepository.GetItemLists();
            var totalItems = items.Count();

            items = _itemRepository.GetSort(sortField, sortDirection, items);

            var pagedItems = _itemRepository.GetPageItems(items, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewBag.SortField = sortField;
            ViewBag.SortDirection = sortDirection;

            return View(pagedItems);
        }

        public async Task<IActionResult> ExportToExcel(string sortField = "ItemId", string sortDirection = "asc")
        {
            var items = await _itemRepository.GetItemLists();

            items = _itemRepository.GetSort(sortField, sortDirection, items).ToList();

            // Create workbook and worksheet
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Result");

                worksheet = _itemRepository.GetItemListWorkSheet(items, worksheet);     

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    var fileName = "Result.xlsx";
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }
        public IActionResult Create()
        {
            return View("CreateItem");
        }

        public async Task<IActionResult> SearchAndEditByItemId(string itemId, string action1)
        {
            // Kiểm tra xem ID nhân viên có được cung cấp không
            if (string.IsNullOrEmpty(itemId))
            {
                TempData["ErrorMessage"] = "Vui lòng nhập ID Vat pham.";
                return RedirectToAction("Item");
            }

            // Lấy thông tin nhân viên từ repository
            var item = await _itemRepository.GetItemId(itemId);

            // Kiểm tra xem item có tồn tại hay không
            if (item == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy Vat pham với ID đã nhập.";
                return RedirectToAction("Item");
            }
        
            if (action1 == "SearchItem") return View("ItemDetails", item);

            if (action1 == "EditItem") return View("EditItem", item);

            TempData["ErrorMessage"] = "Hành động không hợp lệ.";
            return RedirectToAction("Item");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem(Item item)
        {
            ModelState.Remove("GoodsReceiptLot");
            ModelState.Remove("ItemClasses");
            if (ModelState.IsValid)
            {
                try
                {
                    _itemRepository.UnitOfWork.BeginTransaction();

                    await _itemRepository.AddItem(item);

                    await _itemRepository.UnitOfWork.CommitTransactionAsync();
                    TempData["SuccessMessage"] = "Vật phẩm đã được lưu thành công!";
                    return RedirectToAction("Item");
                }
                catch (Exception ex)
                {
                    _itemRepository.UnitOfWork.RollbackTransaction();

                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                        Console.WriteLine($"Inner Stack Trace: {ex.InnerException.StackTrace}");
                    }

                    ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                }
            }
            TempData["ErrorMessage"] = "Vật phẩm đã tồn tại.";
            return View(item); // Nếu không hợp lệ, quay về view Create
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                // Kiểm tra xem các lỗi cụ thể là gì
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _itemRepository.UnitOfWork.BeginTransaction();

                    await _itemRepository.UpdateItem(item);

                    await _itemRepository.UnitOfWork.CommitTransactionAsync();
                    TempData["SuccessMessage"] = "Vật phẩm đã được cập nhật thành công!";
                    return RedirectToAction("Item");
                }
                catch (Exception ex)
                {
                    _itemRepository.UnitOfWork.RollbackTransaction();

                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                        Console.WriteLine($"Inner Stack Trace: {ex.InnerException.StackTrace}");
                    }

                    ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                }
            }
            return View("EditItem", item); // Nếu không hợp lệ, quay về view Edit
        }




    }
}
