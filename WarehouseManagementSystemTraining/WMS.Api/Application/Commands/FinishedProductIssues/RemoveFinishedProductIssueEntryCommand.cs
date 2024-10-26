namespace WMS.Api.Application.Commands.FinishedProductIssues
{
    public class RemoveFinishedProductIssueEntryCommand : IRequest<bool>
    {
        public string FinishedProductIssueId { get; set; }
        public string ItemId { get; set; }
        public string Unit { get; set; }
        public string PurchaseOrderNumber { get; set; }

        public RemoveFinishedProductIssueEntryCommand(string finishedProductIssueEntryId, string finishedProductIssueId, string itemId, 
                                                      string unit, string purchaseOrderNumber)
        {
            FinishedProductIssueId = finishedProductIssueId;
            ItemId = itemId;
            Unit = unit;
            PurchaseOrderNumber = purchaseOrderNumber;
        }
    }
}
