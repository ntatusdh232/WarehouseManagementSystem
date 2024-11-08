﻿using DocumentFormat.OpenXml.InkML;

namespace WMS.Domain.AggregateModels.ItemLotLocationAggregate
{
    public class ItemLotLocation : IAggregateRoot
    {
        public int ItemLotId { get; private set; }
        public string LocationId { get; private set; }
        public double QuantityPerLocation { get; private set; }
        public ItemLot ItemLot { get; private set; }
        public Location Location { get; private set; }

#pragma warning disable CS8618
        private ItemLotLocation() { }

        public ItemLotLocation(int itemLotId, string locationId, double quantityPerLocation)
        {
            ItemLotId = itemLotId;
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
        }

        public ItemLotLocation(string locationId, double quantityPerLocation)
        {
            LocationId = locationId;
            QuantityPerLocation = quantityPerLocation;
        }


#pragma warning restore CS8618
    }
}
