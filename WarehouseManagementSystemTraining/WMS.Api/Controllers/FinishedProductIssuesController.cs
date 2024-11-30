using WMS.Api.Application.Commands.FinishedProductIssues;

namespace WMS.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class FinishedProductIssuesController : ControllerBase
    {
        private IMediator _mediator;

        public FinishedProductIssuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllIds - success")]
        public async Task<IEnumerable<string>> GetAllIds()
        {
            var query = new GetAllIdsQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetAllReceivers - success")]
        public async Task<IEnumerable<string>> GetAllReceivers()
        {
            var query = new GetAllReceiversQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetProductIssueById - success/{Id}")]
        public async Task<FinishedProductIssueViewModel> GetProductIssueById(string Id)
        {
            var query = new GetProductIssueByIdQuery(Id);

            return await _mediator.Send(query);
        }

        [HttpGet("GetProductIssueByTime - success")]
        public async Task<IEnumerable<FinishedProductIssueViewModel>> GetProductIssueByTime([FromQuery] DateTime start, [FromQuery] DateTime stop)
        {
            var Request = new TimeRangeQuery(start.Date, stop.Date);

            var query = new Application.Queries.FinishedProductIssues.GetByTimeQuery(Request);

            return await _mediator.Send(query);
        }

        [HttpPost("Create - success")]
        public async Task<IActionResult> CreateProductIssue([FromBody] CreateFinishedProductIssueCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("AddFinishedProductIssueEntries - Error")]
        public async Task<IActionResult> AddFinishedProductIssueEntries([FromBody] AddFinishedProductIssueEntriesCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("RemoveFinishedProductIssueEntry - success")]
        public async Task<IActionResult> RemoveFinishedProductIssueEntry([FromBody] RemoveFinishedProductIssueEntryCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


    }
}
