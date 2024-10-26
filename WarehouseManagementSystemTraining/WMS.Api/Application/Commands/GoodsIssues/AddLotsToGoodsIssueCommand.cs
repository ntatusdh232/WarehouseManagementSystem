namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class AddLotsToGoodsIssueCommand : IRequest<bool>
    {
        public string GoodsIssueId { get; set; }
        public List<CreateGoodsIssueLotViewModel> GoodsIssueLots { get; set; }

        public AddLotsToGoodsIssueCommand(string goodsIssueId, List<CreateGoodsIssueLotViewModel> goodsIssueLots)
        {
            GoodsIssueId = goodsIssueId;
            GoodsIssueLots = goodsIssueLots;
        }
    }
}
