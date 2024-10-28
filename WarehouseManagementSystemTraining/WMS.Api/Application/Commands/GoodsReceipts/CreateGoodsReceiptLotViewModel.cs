namespace WMS.Api.Application.Commands.GoodsReceipts;

public class CreateGoodsReceiptLotViewModel
{
    public string GoodsReceiptLotId {  get; set; }
    public double Quantity {  get; set; }
    public string ItemId {  get; set; }
    public string Unit {  get; set; }
    public string EmployeeId {  get; set; }
    public string Note { get ; set; }

    public CreateGoodsReceiptLotViewModel(string goodsReceiptLotId, double quantity, string itemId, string unit, string employeeId, string note)
    {
        GoodsReceiptLotId = goodsReceiptLotId;
        Quantity = quantity;
        ItemId = itemId;
        Unit = unit;
        EmployeeId = employeeId;
        Note = note;
    }
}
