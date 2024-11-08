namespace WMS.Api.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public string EntityType { get; } = "";
        public string EntityId { get; } = "";

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string? message, Exception? ex) : base(message, ex)
        {
        }

        public EntityNotFoundException(string entityType, string entityId) : this($"The entity of type '{entityType}' with id '{entityId}' not found.")
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        protected EntityNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {

        }
    }
}
