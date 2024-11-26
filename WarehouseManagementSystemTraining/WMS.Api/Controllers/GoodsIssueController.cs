using WMS.Api.Application.Commands.GoodsIssues;

namespace WMS.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class GoodsIssueController : ControllerBase
    {
        private readonly IGoodsIssueRepository _goodsIssueRepository;
        private readonly IMediator _mediator;

        public GoodsIssueController(IGoodsIssueRepository goodsIssueRepository, IMediator mediator)
        {
            _goodsIssueRepository = goodsIssueRepository;
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        public async Task<IEnumerable<GoodsIssueViewModel>> GetAll()
        {
            var query = new Application.Queries.GoodsIssues.GetAllQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetIds/{isExported}")]
        public async Task<IEnumerable<string>> GetAllIds(bool isExported)
        {
            var query = new GetAllGoodsIssueIdsQuery(isExported);

            return await _mediator.Send(query);
        }

        [HttpGet("GetGoodsIssueById/{Id}")]
        public async Task<GoodsIssueViewModel> GetGoodsIssueById(string Id)
        {
            var query = new GetGoodsIssueByIdQuery(Id);

            return await _mediator.Send(query);
        }

        [HttpGet("GetGoodsIssueByTime")]
        public async Task<IEnumerable<GoodsIssueViewModel>> GetGoodsIssueByTime([FromQuery] DateTime start, [FromQuery] DateTime stop, [FromQuery] bool isExported)
        {
            var timeRange = new TimeRangeQuery(start.Date, stop.Date);
            var query = new GetGoodsIssuesByTimeQuery(timeRange, isExported);
            return await _mediator.Send(query);
        }


        [HttpGet("GetReceivers")]
        public async Task<IEnumerable<string>> GetReceivers()
        {
            var query = new GetReceiversQuery();

            return await _mediator.Send(query);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateGoodsIssue([FromBody] CreateGoodsIssueCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("AddLots - Do not Test")]
        public async Task<IActionResult> AddLotsToGoodsIssue([FromBody] AddLotsToGoodsIssueCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("Remove/{goodsIssueId}")]
        public async Task<IActionResult> RemoveGoodsIssue(string goodsIssueId)
        {
            var command = new RemoveGoodsIssueCommand(goodsIssueId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("RemoveEntry")]
        public async Task<IActionResult> RemoveGoodsIssueEntry([FromBody] RemoveGoodsIssueEntryCommand command)
        {

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateGoodsIssueEntry([FromBody] UpdateGoodsIssueEntryCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
