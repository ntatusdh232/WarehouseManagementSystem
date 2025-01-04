using WMS.Api.Application.Commands.FinishedProductReceipts;

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

        [HttpGet("GetByTime - success")]
        public async Task<IEnumerable<FinishedProductReceiptViewModel>> GetByTime([FromQuery] DateTime start, [FromQuery] DateTime stop)
        {
            var request = new TimeRangeQuery(start,stop);

            var query = new Application.Queries.FinishedProductReceipts.GetByTimeQuery(request);

            return await _mediator.Send(query);
        }
        [HttpGet("GetReceiptById - success/{Id}")]
        public async Task<FinishedProductReceiptViewModel> GetReceiptById(string Id)
        {
            var query = new GetReceiptByIdQuery(Id);

            return await _mediator.Send(query);
        }

        [HttpGet("GetReceiptIds - success")]
        public async Task<IEnumerable<string>> GetReceiptIds()
        {
            var query = new GetReceiptIdsQuery();

            return await _mediator.Send(query);
        }

        [HttpPost("AddEntryToFinishedProductReceipt - Erorr (Not EventHandler)")]
        public async Task<IActionResult> AddEntryToFinishedProductReceipt([FromBody] AddEntryToFinishedProductReceiptCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("CreateProductReceipt - success")]
        public async Task<IActionResult> CreateProductReceipt([FromBody] CreateFinishedProductReceiptCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteFinishedProductReceipt - Error (not EventHandler)/{finishProductReceiptId}")]
        public async Task<IActionResult> DeleteFinishedProductReceipt(string finishProductReceiptId)
        {
            var command = new DeleteFinishedProductReceiptCommand(finishProductReceiptId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("RemoveFinishedProductReceiptEntries - Error( not EventHandler)")]
        public async Task<IActionResult> RemoveFinishedProductReceiptEntries([FromBody] RemoveFinishedProductReceiptEntriesCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateFinishedProductReceiptEntry - Error(GroupAndSum)")]
        public async Task<IActionResult> UpdateFinishedProductReceiptEntry([FromBody] UpdateFinishedProductReceiptEntryCommand request)
        {
            var command = new UpdateFinishedProductReceiptEntryCommand(request.FinishedProductReceiptId,request.Entries);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
