
namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class UpdateGoodsIssueEntryCommand : IRequest<bool>
    {
        public string GoodsIssueId { get; set; }
        public List<UpdateGoodsIssueEntryViewModel> Entries { get; set; }

        public UpdateGoodsIssueEntryCommand(string goodsIssueId, List<UpdateGoodsIssueEntryViewModel> entries)
        {
            GoodsIssueId = goodsIssueId;
            Entries = entries;
        }
    }
}
