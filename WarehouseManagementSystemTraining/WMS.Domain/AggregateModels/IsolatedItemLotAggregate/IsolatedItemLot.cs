using WMS.Domain.AggregateModels.EmployeeAggregate;

namespace WMS.Domain.AggregateModels.IsolatedItemLotAggregate
{
    public class IsolatedItemLot : IAggregateRoot
    {
        public string ItemLotId { get; private set; }
        public double Quantity { get; private set; }
        public DateTime? ProductionDate { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
        public int ItemId { get; private set; }
        public Item Item { get; private set; }

#pragma warning disable CS8618
        private IsolatedItemLot() { }

        public IsolatedItemLot(string itemLotId, double quantity, DateTime? productionDate, DateTime? expirationDate, int itemId)
        {
            ItemLotId = itemLotId;
            Quantity = quantity;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            ItemId = itemId;
        }



#pragma warning restore CS8618




    }
}
