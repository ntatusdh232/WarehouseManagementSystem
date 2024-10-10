using MyProject.Domain.AggregateModels.EmployeeAggregate;
using MyProject.Domain.AggregateModels.FinishedProductIssueEntryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.AggregateModels.FinishedProductIssueAggegrate;

public class FinishedProductIssue : Entity, IAggregateRoot
{
    public string FinishedProductIssueId { get; private set; }
    public string? Receiver {  get; private set; }
    public DateTime Timestamp {  get; private set; }
    public Employee Employee { get; private set; }
    public List<FinishedProductIssueEntry> Entries { get; private set; } = new List<FinishedProductIssueEntry>();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public FinishedProductIssue()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }
    public void AddEntry()
    { }
}
