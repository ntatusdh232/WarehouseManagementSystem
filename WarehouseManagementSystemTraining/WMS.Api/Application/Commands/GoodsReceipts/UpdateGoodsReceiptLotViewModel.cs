namespace WMS.Api.Application.Commands.GoodsReceipts;

public class UpdateGoodsReceiptLotViewModel
{
    public string OldGoodsReceiptLotId {  get; set; }
    public string NewGoodsReceiptLotId { get; set; }
    public List<ItemLotLocationViewModel> ItemLotLocations { get; set; }
    public double Quantity {  get; set; }
    public DateTime ProductionDate {  get; set; }
    public DateTime ExpirationDate {  get; set; }
    public string Note {  get; set; }

    public UpdateGoodsReceiptLotViewModel(string oldGoodsReceiptLotId, string newGoodsReceiptLotId, List<ItemLotLocationViewModel> itemLotLocations, double quantity, DateTime productionDate, DateTime expirationDate, string note)
    {
        OldGoodsReceiptLotId = oldGoodsReceiptLotId;
        NewGoodsReceiptLotId = newGoodsReceiptLotId;
        ItemLotLocations = itemLotLocations;
        Quantity = quantity;
        ProductionDate = productionDate;
        ExpirationDate = expirationDate;
        Note = note;
    }
}
