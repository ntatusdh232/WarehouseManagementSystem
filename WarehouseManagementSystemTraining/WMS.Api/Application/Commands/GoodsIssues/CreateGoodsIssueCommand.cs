namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class CreateGoodsIssueCommand : IRequest<bool>
    {
        public string GoodsIssueId { get; set; }
        public string Receiver { get; set; }
        public string EmployeeId { get; set; }
        public List<CreateGoodsIssueEntryViewModel> Entries { get; set; }

        public CreateGoodsIssueCommand(string goodsIssueId, string receiver, string employeeId, List<CreateGoodsIssueEntryViewModel> entries)
        {
            GoodsIssueId = goodsIssueId;
            Receiver = receiver;
            EmployeeId = employeeId;
            Entries = entries;
        }
    }
}
