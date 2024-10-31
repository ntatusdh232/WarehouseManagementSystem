namespace WMS.Domain.AggregateModels.ItemAggregate
{
    public class ItemClass : IAggregateRoot
    {
        public string ItemClassId { get; set; }

#pragma warning disable CS8618
        private ItemClass() { }

        public ItemClass(string itemClassId)
        {
            ItemClassId = itemClassId;
        }
#pragma warning restore CS8618

    }
}
