namespace WMS.Api.Application.Commands.FinishedProductReceipts;

public class AddEntryToFinishedProductReceiptCommand : IRequest<bool>
{
    public string FinishedProductReceiptId { get; set; }
    public List<CreateFinishedProductReceiptEntryViewModel> Entries { get; set; }

    public AddEntryToFinishedProductReceiptCommand(string finishedProductReceiptId, List<CreateFinishedProductReceiptEntryViewModel> entries)
    {
        FinishedProductReceiptId = finishedProductReceiptId;
        Entries = entries;
    }
}
