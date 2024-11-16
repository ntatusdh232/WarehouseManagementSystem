namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
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


        [HttpGet("GoodsIssue/GetAll")]
        public async Task<IEnumerable<GoodsIssueViewModel>> GetAll()
        {
            var query = new Application.Queries.GoodsIssues.GetAllQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GoodsIssue/GetIds/{isExported}")]
        public async Task<IEnumerable<string>> GetAllIds(bool isExported)
        {
            var query = new GetAllGoodsIssueIdsQuery(isExported);

            return await _mediator.Send(query);
        }

        [HttpGet("GoodsIssue/GetGoodsIssueById/{Id}")]
        public async Task<GoodsIssueViewModel> GetGoodsIssueById(string Id)
        {
            var query = new GetGoodsIssueByIdQuery(Id);

            return await _mediator.Send(query);
        }

        [HttpGet("GoodsIssue/GetGoodsIssueByTime")]
        public async Task<IEnumerable<GoodsIssueViewModel>> GetGoodsIssueByTime([FromQuery] bool isExported)
        {
            var timeRangeQuery = new TimeRangeQuery(DateTime.MinValue, DateTime.Now);
            var query = new GetGoodsIssuesByTimeQuery(timeRangeQuery, isExported);
            return await _mediator.Send(query);
        }

        [HttpGet("GoodsIssue/GetReceivers")]
        public async Task<IEnumerable<string>> GetReceivers()
        {
            var query = new GetReceiversQuery();

            return await _mediator.Send(query);
        }



    }
}
