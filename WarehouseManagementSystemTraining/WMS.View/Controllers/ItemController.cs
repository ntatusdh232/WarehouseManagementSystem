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

            // Sorting logic
            switch (sortField)
            {
                case "ItemId":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.ItemId).ToList()
                        : items.OrderBy(i => i.ItemId).ToList();
                    break;

                case "ItemName":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.ItemName).ToList()
                        : items.OrderBy(i => i.ItemName).ToList();
                    break;

                case "ItemType":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.ItemType).ToList()
                        : items.OrderBy(i => i.ItemType).ToList();
                    break;

                // Thêm các trường hợp khác nếu cần thiết cho các thuộc tính khác
                default:
                    // Sắp xếp mặc định theo ItemId
                    items = items.OrderBy(i => i.ItemId).ToList();
                    break;
            }

            var pagedItems = items
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewBag.SortField = sortField;
            ViewBag.SortDirection = sortDirection;

            return View(pagedItems);
        }

        public async Task<IActionResult> ExportToExcel(string sortField = "ItemId", string sortDirection = "asc")
        {
            var items = await _itemRepository.GetItemLists();

            // Sorting logic
            switch (sortField)
            {
                case "ItemId":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.ItemId).ToList()
                        : items.OrderBy(i => i.ItemId).ToList();
                    break;

                case "ItemName":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.ItemName).ToList()
                        : items.OrderBy(i => i.ItemName).ToList();
                    break;

                case "ItemType":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.ItemType).ToList()
                        : items.OrderBy(i => i.ItemType).ToList();
                    break;
                case "MinimumStockLevel":
                    items = sortDirection.ToLower() == "desc"
                        ? items.OrderByDescending(i => i.MinimumStockLevel).ToList()
                        : items.OrderBy(i => i.MinimumStockLevel).ToList();
                    break;

                // Thêm các trường hợp khác nếu cần thiết cho các thuộc tính khác
                default:
                    // Sắp xếp mặc định theo ItemId
                    items = items.OrderBy(i => i.ItemId).ToList();
                    break;
            }

            // Create workbook and worksheet
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Items");

                // Add headers
                worksheet.Cell(1, 1).Value = "ID Item";
                worksheet.Cell(1, 2).Value = "Tên Item";
                worksheet.Cell(1, 3).Value = "Loại Item";
                worksheet.Cell(1, 4).Value = "Mức tồn kho tối thiểu";
                worksheet.Cell(1, 5).Value = "Kích thước gói";
                worksheet.Cell(1, 6).Value = "Đơn vị gói";
                worksheet.Cell(1, 7).Value = "Giá";
                worksheet.Cell(1, 8).Value = "Đơn vị";

                // Add data
                for (int i = 0; i < items.Count(); i++)
                {
                    var item = items.ElementAt(i);
                    worksheet.Cell(i + 2, 1).Value = item.ItemId;
                    worksheet.Cell(i + 2, 2).Value = item.ItemName;
                    worksheet.Cell(i + 2, 3).Value = item.ItemType;
                    worksheet.Cell(i + 2, 4).Value = item.MinimumStockLevel;
                    worksheet.Cell(i + 2, 5).Value = item.PacketSize;
                    worksheet.Cell(i + 2, 6).Value = item.PacketUnit;
                    worksheet.Cell(i + 2, 7).Value = item.Price;
                    worksheet.Cell(i + 2, 8).Value = item.Unit;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    var fileName = "Items.xlsx";
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }
    }
}
