﻿namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotAdjustmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LotAdjustmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<LotAdjustmentViewModel>> GetAll()
        {
            var query = new Application.Queries.LotAdjustments.GetAllQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetAdjustmentsByTime")]
        public async Task<IEnumerable<LotAdjustmentViewModel>> GetAdjustmentsByTime([FromQuery] DateTime start, [FromQuery] DateTime stop)
        {
            var request = new TimeRangeQuery(start.Date, stop.Date);

            var query = new GetAdjustmentsByTimeQuery(request);

            return await _mediator.Send(query);
        }

        [HttpGet("GetIsConfirmedAdjustments")]
        public async Task<IEnumerable<LotAdjustmentViewModel>> GetIsConfirmedAdjustments([FromQuery] bool isConfirmed)
        {
            var query = new GetIsConfirmedAdjustmentsQuery(isConfirmed);

            return await _mediator.Send(query);
        }
    }
}