namespace WMS.Api.Application.Commands.FinishedProductReceipts;

public class RemoveFinishedProductReceiptEntriesCommand : IRequest<bool>
{
    public string FinishedProductReceiptId { get; set; }
    public List<RemoveFinishedProductEntryViewModel> Entries { get; set; }

    public RemoveFinishedProductReceiptEntriesCommand(string finishedProductReceiptId, List<RemoveFinishedProductEntryViewModel> entries)
    {
        FinishedProductReceiptId = finishedProductReceiptId;
        Entries = entries;
    }
}
