namespace WMS.Api.Application.Queries.GoodsIssues;

public class GoodsIssueLotViewModel
{
    public string GoodsIssueLotId {  get; set; }
    public double Quantity {  get; set; }
    public EmployeeViewModel Employee { get; set; }
    public List<GoodsIssueSublotViewModel> Sublots { get; set; }

    public GoodsIssueLotViewModel(string goodsIssueLotId, double quantity, EmployeeViewModel employee, List<GoodsIssueSublotViewModel> sublots)
    {
        GoodsIssueLotId = goodsIssueLotId;
        Quantity = quantity;
        Employee = employee;
        Sublots = sublots;
    }
}
