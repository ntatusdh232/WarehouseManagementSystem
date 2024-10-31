namespace WMS.Domain.DomainEvents.GoodsIssueEvents
{
    public class ItemLotInformationChangedDomainEvent : INotification
    {
        public ItemLot ItemLot { get; set; }
        public GoodsIssueLot GoodsIssueLot { get; set; }

        public ItemLotInformationChangedDomainEvent(ItemLot itemLot, GoodsIssueLot goodsIssueLot)
        {
            ItemLot = itemLot;
            GoodsIssueLot = goodsIssueLot;
        }
    }
}
