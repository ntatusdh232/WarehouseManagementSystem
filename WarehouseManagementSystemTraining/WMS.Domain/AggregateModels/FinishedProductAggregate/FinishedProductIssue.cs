
using DocumentFormat.OpenXml.Drawing;

namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductIssue : Entity, IAggregateRoot
    {
        [Key]
        public string FinishedProductIssueId { get; set; }

        public string? Receiver { get; set; }
        public DateTime Timestamp { get; set; }

        public List<FinishedProductIssueEntry> Entries { get; set; } 

        [ForeignKey("Employee")]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

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

        public FinishedProductIssue(string finishedProductIssueId, string? receiver, string employeeId)
        {
            FinishedProductIssueId = finishedProductIssueId;
            Receiver = receiver;
            EmployeeId = employeeId;
            Entries = new List<FinishedProductIssueEntry>();
        }

        public void AddIssueEntry(FinishedProductIssueEntry inputEntry)
        {
            bool isEntryExist = false;

            foreach (var entry in Entries)
            {
                if (inputEntry.PurchaseOrderNumber == entry.PurchaseOrderNumber && entry.Item == inputEntry.Item)
                {
                    isEntryExist = true;
                }
            }

            if (isEntryExist == false)
            {
                Entries.Add(inputEntry);
            }
        }

        public void RemoveIssueEntry(string inputItemId, string inputPurchaseOrderNumber)
        {
            bool isEntryExist = false;
            var entryExist = new List<FinishedProductIssueEntry>();

            foreach (var entry in Entries)
            {
                if (entry.ItemId == inputItemId && entry.PurchaseOrderNumber == inputPurchaseOrderNumber)
                {
                    isEntryExist = true;
                    entryExist.Add(entry);
                }
            }

            if (!isEntryExist)
            {
                throw new WarehouseDomainException($"Entry with ItemId: {inputItemId} and PurchaseOrderNumber: {inputPurchaseOrderNumber} does not exist in the FinishedProductIssue");
            }
            else
            {
                // Remove Entries từ list entryExist
                foreach (var entry in entryExist)
                {
                    Entries.Remove(entry);
                }

            }

        }

        public void UpdateFinishedProductInventory(Item item, string purchaseOrderNumber, double quantity)
        {
            AddDomainEvent(new UpdateInventoryOnCreateProductIssueDomainEvent(item, purchaseOrderNumber, quantity));
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



#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.





    }
}
