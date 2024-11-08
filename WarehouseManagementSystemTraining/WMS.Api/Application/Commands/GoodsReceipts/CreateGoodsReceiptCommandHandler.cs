
namespace WMS.Api.Application.Commands.GoodsReceipts;

public class CreateGoodsReceiptCommandHandler : IRequestHandler<CreateGoodsReceiptCommand, bool>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IGoodsReceiptRepository _goodsReceiptRepository;
    private readonly IItemRepository _itemRepository;

    public CreateGoodsReceiptCommandHandler(IEmployeeRepository employeeRepository, IGoodsReceiptRepository goodsReceiptRepository, IItemRepository itemRepository)
    {
        _employeeRepository = employeeRepository;
        _goodsReceiptRepository = goodsReceiptRepository;
        _itemRepository = itemRepository;
    }

    public async Task<bool> Handle(CreateGoodsReceiptCommand request, CancellationToken cancellationToken)
    {
        var goodsReceiptEmployee = await _employeeRepository.GetEmployeeById(request.EmployeeId);
        if (goodsReceiptEmployee is null)
        {
            throw new EntityNotFoundException(nameof(Employee), request.EmployeeId);
        }
        var existedGoodsReceipt = await _goodsReceiptRepository.GetGoodsReceiptByGoodsReceiptId(request.GoodsReceiptId);
        if (existedGoodsReceipt != null)
        {
            throw new DuplicatedRecordException(nameof(GoodsReceipt), request.GoodsReceiptId);
        }
        var newGoodsReceipt = new GoodsReceipt(goodsReceiptId: request.GoodsReceiptId,
                                                supplier: request.Supplier,
                                                employeeId: request.EmployeeId);
        var itemLots = new List<ItemLot>();
        foreach (var receiptLotViewModel in request.GoodsReceiptLots)
        {
            var item = await _itemRepository.GetItemById(receiptLotViewModel.ItemId);
            if (item is null)
            {
                throw new EntityNotFoundException(nameof(Item), receiptLotViewModel.ItemId);
            }
            var employee = await _employeeRepository.GetEmployeeById(receiptLotViewModel.EmployeeId);
            if (employee is null)
            {
                throw new EntityNotFoundException(nameof(Employee), receiptLotViewModel.EmployeeId);
            }
            var newGoodsReceiptLot = new GoodsReceiptLot(goodsReceiptLotId: receiptLotViewModel.GoodsReceiptLotId,
                                                         quantity: receiptLotViewModel.Quantity,
                                                         itemId: receiptLotViewModel.ItemId,
                                                         employeeId: receiptLotViewModel.EmployeeId,
                                                         note: receiptLotViewModel.Note);
            var newitemLot = new ItemLot(quantity: receiptLotViewModel.Quantity,
                                         item: item,
                                         itemId: receiptLotViewModel.ItemId);
            itemLots.Add(newitemLot);
            newGoodsReceipt.AddLot(newGoodsReceiptLot);
        }
        foreach (var itemLot in itemLots)
        {
            itemLot.Confirm();
        }
        await _goodsReceiptRepository.Add(newGoodsReceipt);

        return await _goodsReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}