namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class ItemClass : IAggregateRoot
    {
        public string ItemClassId { get; set; }
        public string Itemid { get; set; }
        public Item Item { get; set; }
    }
}
