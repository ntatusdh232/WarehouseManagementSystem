namespace WMS.Api.Application.Queries.GoodsIssues;

public class GoodsIssueEntryViewModel
{
    public double RequestedQuantity { get; set; }
    public ItemViewModel Item { get; set; }
    public List<GoodsIssueLotViewModel> Lots {  get; set; }

    public GoodsIssueEntryViewModel(double requestedQuantity, ItemViewModel item, List<GoodsIssueLotViewModel> lots)
    {
        RequestedQuantity = requestedQuantity;
        Item = item;
        Lots = lots;
    }
}
