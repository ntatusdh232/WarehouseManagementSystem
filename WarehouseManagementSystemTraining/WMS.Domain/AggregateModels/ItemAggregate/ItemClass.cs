namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class ItemClass : IAggregateRoot
    {
        public string ItemClassId { get; set; }

        [ForeignKey("Item")]
        public string ItemId{ get; set; }
        public Item Item { get; set; }

#pragma warning disable CS8618
        private ItemClass() { }

        public ItemClass(string itemClassId)
        {
            ItemClassId = itemClassId;
        }
#pragma warning restore CS8618

    }
}
