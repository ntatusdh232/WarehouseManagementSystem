namespace WMS.Api.Application.Commands.FinishedProductReceipts;

public class CreateFinishedProductReceiptCommand : IRequest<bool>
{
    public string FinishedProductReceiptId { get; set; }
    public string EmployeeId { get; set; }
    public List<CreateFinishedProductReceiptEntryViewModel> Entries { get; set; }

    public CreateFinishedProductReceiptCommand(string finishedProductReceiptId, string employeeId, List<CreateFinishedProductReceiptEntryViewModel> entries)
    {
        FinishedProductReceiptId = finishedProductReceiptId;
        EmployeeId = employeeId;
        Entries = entries;
    }
}
