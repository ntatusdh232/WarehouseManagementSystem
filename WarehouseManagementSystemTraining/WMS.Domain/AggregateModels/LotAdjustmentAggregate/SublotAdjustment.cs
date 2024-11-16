namespace WMS.Domain.AggregateModels.LotAdjustmentAggregate
{
    public class SublotAdjustment : IAggregateRoot
    {
        [Key]
        public string SublotAdjustmentId { get; private set; }

        public string LocationId { get; private set; }
        public double BeforeQuantityPerLocation { get; private set; }
        public double AfterQuantityPerLocation { get; private set; }

        [ForeignKey("LotAdjustment")]
        public string LotAdjustmentId { get; private set; }
        public LotAdjustment LotAdjustment { get; private set; }

#pragma warning disable CS8618
        private SublotAdjustment() { }

        public SublotAdjustment(string locationId, double beforeQuantityPerLocation, double afterQuantityPerLocation)
        {
            LocationId = locationId;
            BeforeQuantityPerLocation = beforeQuantityPerLocation;
            AfterQuantityPerLocation = afterQuantityPerLocation;
        }



#pragma warning restore CS8618

    }
}
