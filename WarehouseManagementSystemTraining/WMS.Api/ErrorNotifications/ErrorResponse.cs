namespace WMS.Api.ErrorNotifications
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public object Detail { get; set; }

        public ErrorResponse(string errorCode, string message, object detail)
        {
            Code = errorCode;
            Message = message;
            Detail = detail;
        }

        public ErrorResponse(Exception ex)
        {
            Code = "Unexpected";
            Message = ex.Message;
            var innerMessage = ex.InnerException?.Message;
            if (!string.IsNullOrEmpty(innerMessage))
            {
                Detail = innerMessage;
            }
            else
            {
                Detail = "";
            }
        }

        public ErrorResponse(DuplicatedRecordErrorDetail ex)
        {
            Code = $"RecordDuplication.{ex.EntityType}";
            Message = $"The entity of type '{ex.EntityType}' with ID '{ex.EntityId}' already exists";
            Detail = new DuplicatedRecordErrorDetail(ex.EntityType, ex.EntityId);
        }

        public ErrorResponse(EntityNotFoundErrorDetail ex)
        {
            Code = $"NotFound.{ex.EntityType}";
            Message = $"The entity of type {ex.EntityType} with ID {ex.EntityId} not found.";
            Detail = new EntityNotFoundErrorDetail(ex.EntityType, ex.EntityId);
        }
    }

}
