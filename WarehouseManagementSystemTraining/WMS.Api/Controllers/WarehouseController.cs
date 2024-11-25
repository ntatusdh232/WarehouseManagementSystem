using WMS.Api.Application.Commands.Warehouses;
using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Api.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        public async Task<IEnumerable<WarehouseViewModel>> GetAll()
        {
            var query = new GetAllWarehousesQuery();

            return await _mediator.Send(query);
        }

        [HttpGet("GetWarehouseById/{warehouseId}")]
        public async Task<WarehouseViewModel> GetWarehouseById(string warehouseId)
        {
            var query = new GetWarehouseByIdQuery(warehouseId);

            return await _mediator.Send(query);
        }

    }

}
