using MyProject.Domain.AggregateModels.EmployeeAggregate;
using MyProject.Domain.AggregateModels.FinishedProductReceiptEntryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.AggregateModels.FinishProductReceiptAggregate;

public class FinishedProductReceipt : Entity, IAggregateRoot
{
    public string FinishedProductReceiptId {  get; private set; }
    public DateTime Timestamp {  get; private set; }
    public Employee Employee { get; private set; }

    public List<FinishedProductReceiptEntry> Entries = new List<FinishedProductReceiptEntry>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public FinishedProductReceipt()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }

    public void AddEntry()
    { }
}
