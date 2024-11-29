namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinishedProductReceiptController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinishedProductReceiptController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetByTime - ERROR")]
        public async Task<IEnumerable<FinishedProductReceiptViewModel>> GetByTime([FromQuery] DateTime start, [FromQuery] DateTime stop)
        {
            var request = new TimeRangeQuery(start.Date, stop.Date);

            var query = new Application.Queries.FinishedProductReceipts.GetByTimeQuery(request);

            return await _mediator.Send(query);
        }
        [HttpGet("GetReceiptById/{Id}")]
        public async Task<FinishedProductReceiptViewModel> GetReceiptById(string Id)
        {
            var query = new GetReceiptByIdQuery(Id);

            return await _mediator.Send(query);
        }

        [HttpGet("GetReceiptIds")]
        public async Task<IEnumerable<string>> GetReceiptIds()
        {
            var query = new GetReceiptIdsQuery();

            return await _mediator.Send(query);
        }
    }
}
