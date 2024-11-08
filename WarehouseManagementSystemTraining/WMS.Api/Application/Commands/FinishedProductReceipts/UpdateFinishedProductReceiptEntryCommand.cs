namespace WMS.Api.Application.Commands.FinishedProductReceipts
{
    public class UpdateFinishedProductReceiptEntryCommand : IRequest<bool>
    {
        public string FinishedProductReceiptId { get; set; }
        public List<UpdateFinishedProductReceiptEntryViewModel> Entries { get; set; }


        public UpdateFinishedProductReceiptEntryCommand(string finishedProductReceiptId, List<UpdateFinishedProductReceiptEntryViewModel> entries)
        {
            FinishedProductReceiptId = finishedProductReceiptId;
            Entries = entries;
        }
    }
}
