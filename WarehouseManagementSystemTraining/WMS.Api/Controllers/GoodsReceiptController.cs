using WMS.Api.Application.Commands.Employees;
using WMS.Api.Application.Commands.FinishedProductIssues;
using WMS.Api.Application.Commands.FinishedProductReceipts;
using WMS.Api.Application.Commands.GoodsIssues;
using WMS.Api.Application.Commands.GoodsReceipts;

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

        [HttpGet("GetAll - success")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetAll()
        {
            var query = new Application.Queries.GoodsReceipts.GetAllQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetCompletedGoodsReceipts - Not sure")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetCompletedGoodsReceipts()
        {
            var query = new GetCompletedGoodsReceiptsQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetGoodsReceiptsById - success/{Id}")]
        public async Task<GoodsReceiptViewModel> GetGoodsReceiptsById(string Id)
        {
            var query = new GetGoodsReceiptByIdQuery(Id);

            return await _mediator.Send(query);
        }

        [HttpGet("GetGoodsReceiptByTime - success")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetGoodsReceiptByTime([FromQuery] DateTime start, 
                                                                                    [FromQuery] DateTime stop, 
                                                                                    [FromQuery] bool isExported)
        {
            var timeRange = new TimeRangeQuery(start.Date, stop.Date);
            var query = new GetGoodsReceiptsByTimeQuery(timeRange, isExported);
            return await _mediator.Send(query);
        }

        [HttpGet("GetSuppliers - success")]
        public async Task<IList<string>> GetSuppliers()
        {
            var query = new GetSuppliersQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetUnCompletedGoodsReceipts - Not sure")]
        public async Task<IEnumerable<GoodsReceiptViewModel>> GetUnCompletedGoodsReceipts()
        {
            var query = new GetUnCompletedGoodsReceiptsQuery();

            return await _mediator.Send(query);
        }

        [HttpPost("CreateGoodsReceipt - success(CheckError)")]
        public async Task<IActionResult> CreateGoodsReceipt([FromBody] CreateGoodsReceiptCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("AddLots - success(CheckError)")]
        public async Task<IActionResult> AddLotsToGoodsReceipt([FromBody] AddLotsToGoodsReceiptCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteGoodsReceipt - Error (not Event)/{goodsReceiptId}")]
        public async Task<IActionResult> RemoveGoodsReceipt(string goodsReceiptId)
        {
            var command = new DeleteGoodsReceiptCommand(goodsReceiptId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("RemoveGoodsReceiptLots - Error (not Event")]
        public async Task<IActionResult> RemoveGoodsReceiptLots([FromBody] RemoveGoodsReceiptLotsCommand command)
        {

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateGoodsReceipt - Error(LotId)")]
        public async Task<IActionResult> UpdateGoodsReceipt([FromBody] UpdateGoodsReceiptCommand request)
        {
            var command = new UpdateGoodsReceiptCommand(request.GoodsReceiptId ,request.GoodsReceiptLots);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
