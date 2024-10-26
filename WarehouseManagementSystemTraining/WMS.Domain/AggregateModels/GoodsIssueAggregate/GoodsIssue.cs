namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public class GoodsIssue : IAggregateRoot
    {
        public string GoodsIssueId { get; set; }
        public string? Receiver { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public List<GoodsIssueEntry> Entries { get; set; }
        public string EmployeeId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public GoodsIssue()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
        }

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

        public void AddEntry(GoodsIssueEntry goodsIssueEntry)
        {

        }
        public void SetQuantity(string itemId, double quantity)
        {

        }
        public void AddLot(string itemId, GoodsIssueLot goodsIssueLot)
        {

        }
        
        public void Confirm()
        {

        }

    }
}
