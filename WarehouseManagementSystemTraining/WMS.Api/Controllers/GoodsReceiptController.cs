namespace WMS.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class GoodsReceiptController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoodsReceiptController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetAll()
        {
            var query = new Application.Queries.GoodsReceipts.GetAllQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetCompletedGoodsReceipts")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetCompletedGoodsReceipts()
        {
            var query = new GetCompletedGoodsReceiptsQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetGoodsReceiptsById/{Id}")]
        public async Task<GoodsReceiptViewModel> GetGoodsReceiptsById(string Id)
        {
            var query = new GetGoodsReceiptByIdQuery(Id);

            return await _mediator.Send(query);
        }

        [HttpGet("GetGoodsReceiptByTime")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetGoodsReceiptByTime([FromQuery] DateTime start, 
                                                                                    [FromQuery] DateTime stop, 
                                                                                    [FromQuery] bool isExported)
        {
            var timeRange = new TimeRangeQuery(start.Date, stop.Date);
            var query = new GetGoodsReceiptsByTimeQuery(timeRange, isExported);
            return await _mediator.Send(query);
        }

        [HttpGet("GetSuppliers")]
        public async Task<IList<string>> GetSuppliers()
        {
            var query = new GetSuppliersQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetUnCompletedGoodsReceipts")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetUnCompletedGoodsReceipts()
        {
            var query = new GetUnCompletedGoodsReceiptsQuery();

            return await _mediator.Send(query);
        }


    }
}
