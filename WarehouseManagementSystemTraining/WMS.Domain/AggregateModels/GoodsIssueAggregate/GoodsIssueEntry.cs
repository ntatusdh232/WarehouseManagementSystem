﻿namespace WMS.Domain.AggregateModels.GoodsIssueAggregate
{
    public class GoodsIssueEntry : IAggregateRoot
    {
        [Key]
        public string GoodsIssueEntryId { get; set; }

        public double RequestedQuantity { get; set; }

        public List<GoodsIssueLot> Lots { get; set; }

        [ForeignKey("Item")]
        public string ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey("GoodsIssue")]
        public string GoodsIssueId { get; set; }
        public GoodsIssue GoodsIssue { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsIssueEntry() { }
        public GoodsIssueEntry(Item item, double requestedQuantity)
        {
            GoodsIssueEntryId = Guid.NewGuid().ToString();
            RequestedQuantity = requestedQuantity;
            Item = item;
            Lots = new List<GoodsIssueLot>();


        }
        public GoodsIssueEntry(string goodsIssueEntryId, double requestedQuantity, Item item, List<GoodsIssueLot> lots, string itemId, string goodsIssueId)
        {
            GoodsIssueEntryId = goodsIssueEntryId;
            RequestedQuantity = requestedQuantity;
            Item = item;
            Lots = lots;
            ItemId = itemId;
            GoodsIssueId = goodsIssueId;
        }

        public GoodsIssueEntry(string goodsIssueEntryId, double requestedQuantity, Item item, string itemId)
        {
            GoodsIssueEntryId = goodsIssueEntryId;
            RequestedQuantity = requestedQuantity;
            Item = item;
            ItemId = itemId;
        }

        public void AddLot(GoodsIssueLot lot)
        {
            var existedLot = Lots.Find(l => l.GoodsIssueLotId == lot.GoodsIssueLotId);
            if (existedLot is not null)
            {
                throw new WarehouseDomainException($"GoodsIssueLot with Id {lot.GoodsIssueLotId} already existed in this goodsIssue.");
            }
            Lots.Add(lot);
        }


        public void UpdateEntry(double requestedQuantity)
        {
            RequestedQuantity = requestedQuantity;
        }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


    }
}
