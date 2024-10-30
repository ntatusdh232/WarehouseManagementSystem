namespace WMS.Api.Application.Queries.ItemLots;

public class ItemLotViewModel
{
    public string LotId { get; set; }
    public bool IsIsolated { get; set; }
    public double Quantity {  get; set; }
    public DateTime ProductionDate {  get; set; }
    public DateTime ExpirationDate {  get; set; }
    public List<ItemSublotViewModel> ItemLotLocations {  get; set; }
    public ItemViewModel Item { get; set; }
    public double NumOfPackets {  get; set; }

    public ItemLotViewModel(string lotId, bool isIsolated, double quantity, DateTime productionDate, DateTime expirationDate, List<ItemSublotViewModel> itemLotLocations, ItemViewModel item, double numOfPackets)
    {
        LotId = lotId;
        IsIsolated = isIsolated;
        Quantity = quantity;
        ProductionDate = productionDate;
        ExpirationDate = expirationDate;
        ItemLotLocations = itemLotLocations;
        Item = item;
        NumOfPackets = numOfPackets;
    }
}
