using DocumentFormat.OpenXml.Packaging;
using System.Linq;
using WMS.Domain.DomainEvents.FinishedProductReceiptEvents;

namespace WMS.Domain.AggregateModels.FinishedProductAggregate
{
    public class FinishedProductReceipt : Entity, IAggregateRoot
    {
        public string FinishedProductReceiptId { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public List<FinishedProductReceiptEntry> Entries { get; set; }
        public string EmployeeId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private FinishedProductReceipt() { }
        public FinishedProductReceipt(string finishedProductReceiptId, DateTime timestamp, Employee employee, List<FinishedProductReceiptEntry> entries, string employeeId)
        {
            FinishedProductReceiptId = finishedProductReceiptId;
            Timestamp = timestamp;
            Employee = employee;
            Entries = entries;
            EmployeeId = employeeId;
        }

        public FinishedProductReceipt(string finishedProductReceiptId, string employeeId)
        {
            FinishedProductReceiptId = finishedProductReceiptId;
            EmployeeId = employeeId;
        }
        public void AddReceiptEntry(FinishedProductReceiptEntry inputEntry)
        {
            bool isEntryExist = false;
            foreach (var entry in Entries)
            {
                if (inputEntry.PurchaseOrderNumber == entry.PurchaseOrderNumber && entry.Item == inputEntry.Item)
                {
                    isEntryExist = true;
                }
            }

            if (!isEntryExist)
            {
                Entries.Add(inputEntry);
            }
        }

        public void UpdateFinishedProductReceipt(DateTime timestamp, Employee employee,
                                                 List<FinishedProductReceiptEntry> entries)
        {
            Timestamp = timestamp;
            Employee = employee;
            Entries = entries;
        }

        public void RemoveFinishedProductInventory(Item item, string purchaseOrderNumber)
        {
            var entry = Entries.Find(e => e.Item.ItemId == item.ItemId && e.PurchaseOrderNumber == purchaseOrderNumber);
            if (entry == null)
            {
                throw new WarehouseDomainException($"Entry with item {item.ItemName} & {purchaseOrderNumber} not found.");
            }

            AddDomainEvent(new UpdateInventoryOnRemoveProductReceiptEntryDomainEvent(item, purchaseOrderNumber, entry.Quantity));
        }



        public void RemoveReceiptEntry(Item item, string purchaseOrderNumber)
        {

            var entry = Entries.Find(e => e.Item == item && e.PurchaseOrderNumber == purchaseOrderNumber);
            if (entry == null)
            {
                throw new WarehouseDomainException($"Entry with item {item.ItemName} & {purchaseOrderNumber} not found.");
            }
            Entries.Remove(entry);

        }

        public void UpdateFinishedProductInventory(Item item, string oldPurchaseOrderNumber, string newPurchaseOrderNumber, double newQuantity, DateTime timestamp)
        {
            var entry = Entries.Find(e => e.Item == item && e.PurchaseOrderNumber == oldPurchaseOrderNumber);
            if (entry == null)
            {
                throw new WarehouseDomainException($"Entry with item {item.ItemName} & {oldPurchaseOrderNumber} not found.");
            }
            double oldQuantity = entry.Quantity;

            // Sửa số PO và số lượng của 1 entry --> Cập nhật tồn kho TP    
            AddDomainEvent(new UpdateInventoryOnModifyProductReceiptEntryDomainEvent(oldPurchaseOrderNumber, newPurchaseOrderNumber, oldQuantity, newQuantity, timestamp, item));
        }


        public void UpdateFinishedProductInventory(string purchaseOrderNumber, double quantity, DateTime timestamp, Item item )
        {
            var entry = Entries.Find(e => e.Item == item && e.PurchaseOrderNumber == purchaseOrderNumber);
            if (entry == null)
            {
                throw new WarehouseDomainException($"Entry with item {item.ItemName} & {purchaseOrderNumber} not found.");
            }
            double oldQuantity = entry.Quantity;

            // Sửa số PO và số lượng của 1 entry --> Cập nhật tồn kho TP    
            AddDomainEvent(new UpdateInventoryOnCreateProductReceiptDomainEvent(purchaseOrderNumber, quantity, timestamp , item));
        }

        public List<FinishedProductReceiptEntry> GroupAndSumEntries()
        {
            var groupedEntries = Entries
                .GroupBy(entry => new { entry.PurchaseOrderNumber, entry.ItemId })
                .Select(group => new FinishedProductReceiptEntry
                (
                    group.Key.PurchaseOrderNumber,
                    group.Sum(entry => entry.Quantity),
                    group.First().Note,
                    Entries[0].FinishedProductReceiptId,
                    group.First().Item

                ))
                .ToList();

            Entries = groupedEntries;
            return groupedEntries;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.




    }
}
