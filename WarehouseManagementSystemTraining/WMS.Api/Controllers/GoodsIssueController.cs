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



    }
}
