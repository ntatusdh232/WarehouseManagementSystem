﻿namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductIssue : IAggregateRoot
    { 
        public string FinishedProductIssueId { get; set; }
        public string? Receiver { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public List<FinishedProductIssueEntry> Entries { get; set; }
        public string EmployeeId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private FinishedProductIssue() { }
        public FinishedProductIssue(string finishedProductIssueId, string? receiver, DateTime timestamp, Employee employee, List<FinishedProductIssueEntry> entries, string employeeId)
        {
            FinishedProductIssueId = finishedProductIssueId;
            Receiver = receiver;
            Timestamp = timestamp;
            Employee = employee;
            Entries = entries;
            EmployeeId = employeeId;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void AddEntry(FinishedProductIssueEntry inputEntry)
        {
            foreach (var entry in Entries)
            {

                if (inputEntry.PurchaseOrderNumber != entry.PurchaseOrderNumber && entry.Item == null)
                {
                    Entries.Add(inputEntry);
                }
            }
        }

        public void UpdateEntry(List<FinishedProductIssueEntry> entries)
        {
            Entries = entries;
        }

        public void UpdateFinishedProductIssue(string? receiver, DateTime timestamp, 
                                               Employee employee, List<FinishedProductIssueEntry> entries)
        {
            Receiver = receiver;
            Timestamp = timestamp;
            Employee = employee;
            Entries = entries;

        }

    }
}
