namespace WMS.Api.Exceptions
{
    [Serializable]
    public class DuplicatedRecordException : Exception
    {
        public string EntityType { get; } = "";
        public string EntityId { get; } = "";

        public DuplicatedRecordException(string message) : base(message)
        {

        }

        public DuplicatedRecordException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

        public DuplicatedRecordException(string entityType, string entityId) : this($"The entity of type '{entityType}' with id '{entityId}' already exists.")
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        protected DuplicatedRecordException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {

        }
    }
}

