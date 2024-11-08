namespace WMS.Api.Application.Commands.GoodsIssues.GoodsIssueViewModels
{
    public class CreateGoodsIssueLotViewModel
    {
        public string GoodsIssueLotId { get; set; }
        public double Quantity { get; set; }
        public string? Note { get; set; }
        public string EmployeeId { get; set; }
        public List<GoodsIssueSublot> Sublots { get; set; }
        public List<ItemLotLocation> ItemLotLocations { get; set; }

        public CreateGoodsIssueLotViewModel(string goodsIssueLotId, double quantity, string? note, string employeeId, List<GoodsIssueSublot> sublots, List<ItemLotLocation> itemLotLocations)
        {
            GoodsIssueLotId = goodsIssueLotId;
            Quantity = quantity;
            Note = note;
            EmployeeId = employeeId;
            Sublots = sublots;
            ItemLotLocations = itemLotLocations;
        }
    }
}
