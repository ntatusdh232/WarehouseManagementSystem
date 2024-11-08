namespace WMS.Api.Exceptions
{
    [Serializable]
    public class ExportedItemLotException : Exception
    {
        public string ItemLotId { get; }

        public ExportedItemLotException(string itemLotId)
        {
            ItemLotId = itemLotId;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected ExportedItemLotException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {

        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }

}
