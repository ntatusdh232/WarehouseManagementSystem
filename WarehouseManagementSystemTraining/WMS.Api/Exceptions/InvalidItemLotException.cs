[Serializable]
public class InvalidItemLotException : Exception
{
    public string EntityType { get; } = "";
    public string EntityId { get; } = "";

    public InvalidItemLotException(string message) : base(message)
    {

    }

    protected InvalidItemLotException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
    {

    }
}
