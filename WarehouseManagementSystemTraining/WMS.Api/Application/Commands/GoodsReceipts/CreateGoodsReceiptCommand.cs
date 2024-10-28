namespace WMS.Api.Application.Commands.GoodsReceipts;

public class CreateGoodsReceiptCommand : IRequest<bool>
{
    public string GoodsReceiptId {  get; set; }
    public string Supplier {  get; set; }
    public string EmployeeId { get; set; }
    public List<CreateGoodsReceiptLotViewModel> GoodsReceiptLots {  get; set; }

    public CreateGoodsReceiptCommand(string goodsReceiptId, string supplier, string employeeId, List<CreateGoodsReceiptLotViewModel> goodsReceiptLots)
    {
        GoodsReceiptId = goodsReceiptId;
        Supplier = supplier;
        EmployeeId = employeeId;
        GoodsReceiptLots = goodsReceiptLots;
    }
}
