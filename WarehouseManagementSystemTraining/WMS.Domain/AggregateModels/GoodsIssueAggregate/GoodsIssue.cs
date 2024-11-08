namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public class GoodsIssue : IAggregateRoot
    {
        public string GoodsIssueId { get; set; }
        public string Receiver { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public List<GoodsIssueEntry> Entries { get; set; }
        public string EmployeeId { get; set; }



#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsIssue() { }
        public GoodsIssue(string goodsIssueId, string receiver, string employeeId)
        {
            GoodsIssueId = goodsIssueId;
            Receiver = receiver;
            EmployeeId = employeeId;
        }
        public GoodsIssue(string goodsIssueId, string receiver, DateTime timestamp, Employee employee, List<GoodsIssueEntry> entries, string employeeId)
        {
            GoodsIssueId = goodsIssueId;
            Receiver = receiver;
            Timestamp = timestamp;
            Employee = employee;
            Entries = entries;
            EmployeeId = employeeId;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void UpdateGoodsIssue(string receiver, DateTime timestamp)
        {
            Receiver = receiver;
            Timestamp = timestamp;
        }

        public void Update(GoodsIssue goodsIssue)
        {
            GoodsIssueId = goodsIssue.GoodsIssueId;
            Receiver = goodsIssue.Receiver;
            Timestamp = goodsIssue.Timestamp;
            Employee = goodsIssue.Employee;
            Entries = goodsIssue.Entries;
            EmployeeId = goodsIssue.EmployeeId;

        }

        public void MergeEntries(List<GoodsIssueEntry> newEntries)
        {
            foreach (var newEntry in newEntries)
            {
                var existingEntry = Entries.FirstOrDefault(e => e.ItemId == newEntry.ItemId);

                if (existingEntry != null)
                {
                    existingEntry.RequestedQuantity += newEntry.RequestedQuantity;
                    existingEntry.Item.Unit = newEntry.Item.Unit;
                }
                else
                {
                    Entries.Add(newEntry);
                }
            }
        }

        public void AddEntry(Item item, double requestedQuantity)
        {
            var newEntry = new GoodsIssueEntry(item, requestedQuantity);
            foreach (var existedEntry in Entries)
            {
                if (newEntry.Item == existedEntry.Item)
                {
                    throw new WarehouseDomainException($"Entry with Item {newEntry.Item.ItemId} has already existed in the GoodsIssue");
                }
            }
            Entries.Add(newEntry);
        }

        public void AddLot(string itemId, string unit, GoodsIssueLot lot)
        {
            var entry = Entries.Find(e => e.Item.ItemId == itemId && e.Item.Unit == unit);
            if (entry == null)
            {
                throw new WarehouseDomainException($"Entry with Item {itemId} doesn't exist");
            }
            entry.AddLot(lot);
        }

        public void UpdateEntry(string itemId, string unit, double quantity)
        {
            var entry = Entries.SingleOrDefault(entry => entry.Item.ItemId == itemId && entry.Item.Unit == unit);
            if (entry == null)
            {
                throw new WarehouseDomainException($"Entry having item {itemId} with unit {unit} doesn't exist in the current GoodsIssue.");
            }
            entry.UpdateEntry(quantity);
        }


        public void Confirm()
        {


        }

    }
}
