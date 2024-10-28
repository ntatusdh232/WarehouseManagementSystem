namespace WMS.Api.Application.Commands.FinishedProductReceipts;

public class DeleteFinishedProductReceiptCommand : IRequest<bool>
{
    public string FinishedProductReceiptId { get; set; }

    public DeleteFinishedProductReceiptCommand(string finishedProductReceiptId)
    {
        FinishedProductReceiptId = finishedProductReceiptId;
    }
}
