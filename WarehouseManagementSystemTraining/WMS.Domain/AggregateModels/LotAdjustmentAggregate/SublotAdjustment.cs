namespace WMS.Domain.AggregateModels.LotAdjustmentAggregate
{
    public class SublotAdjustment : IAggregateRoot
    {
        public string LocationId { get; private set; }
        public double BeforeQuantityPerLocation { get; private set; }
        public double AfterQuantityPerLocation { get; private set; }

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
