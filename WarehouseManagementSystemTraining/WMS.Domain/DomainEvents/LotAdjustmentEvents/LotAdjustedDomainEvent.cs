namespace WMS.Domain.DomainEvents.LotAdjustmentEvents
{
    public class LotAdjustedDomainEvent : INotification
    {
        public string LotId { get; set; }
        public string ItemId { get; set; }
        public double BeforeQuantity { get; set; }
        public double AfterQuantity { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; }
        public List<SublotAdjustment> sublotLotAdjustments { get; set; }

        public LotAdjustedDomainEvent(string lotId, string itemId, double beforeQuantity, double afterQuantity, string unit, 
                                      DateTime timestamp, List<SublotAdjustment> sublotLotAdjustments)
        {
            LotId = lotId;
            ItemId = itemId;
            BeforeQuantity = beforeQuantity;
            AfterQuantity = afterQuantity;
            Unit = unit;
            Timestamp = timestamp;
            this.sublotLotAdjustments = sublotLotAdjustments;
        }
    }

}
