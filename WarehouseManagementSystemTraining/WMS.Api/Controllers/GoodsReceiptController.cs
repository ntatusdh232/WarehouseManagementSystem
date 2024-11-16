namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsReceiptController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GoodsReceiptController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GoodsReceipt/GetAll")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetAll()
        {
            var query = new Application.Queries.GoodsReceipts.GetAllQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GoodsReceipt/GetCompletedGoodsReceipts")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetCompletedGoodsReceipts()
        {
            var query = new GetCompletedGoodsReceiptsQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GoodsReceipt/GetGoodsReceiptsById/{Id}")]
        public async Task<GoodsReceiptViewModel> GetGoodsReceiptsById(string Id)
        {
            var query = new GetGoodsReceiptByIdQuery(Id);

            return await _mediator.Send(query);
        }

        [HttpGet("GoodsReceipt/GetGoodsReceiptByTime")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GoodsReceipt([FromQuery] bool isExported)
        {
            var timeRangeQuery = new TimeRangeQuery(DateTime.MinValue, DateTime.Now);
            var query = new GetGoodsReceiptsByTimeQuery(timeRangeQuery, isExported);
            return await _mediator.Send(query);
        }

        [HttpGet("GoodsReceipt/GetSuppliers")]
        public async Task<IList<string>> GetSuppliers()
        {
            var query = new GetSuppliersQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GoodsReceipt/GetUnCompletedGoodsReceipts")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetUnCompletedGoodsReceipts()
        {
            var query = new GetUnCompletedGoodsReceiptsQuery();

            return await _mediator.Send(query);
        }


    }
}
