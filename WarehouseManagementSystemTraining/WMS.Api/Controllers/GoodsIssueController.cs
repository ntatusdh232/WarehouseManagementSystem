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
        public async Task<IEnumerable<GoodsIssueViewModel>> GetGoodsIssueByTime([FromBody] GetGoodsIssuesByTimeQuery getGoodsIssuesByTimeQuery)
        {
            var query = new GetGoodsIssuesByTimeQuery(getGoodsIssuesByTimeQuery.Query, getGoodsIssuesByTimeQuery.isExported);

            return await _mediator.Send(query);
        }





    }
}
