namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("Warehouse/GetAll")]
        public async Task<IEnumerable<WarehouseViewModel>> GetAll()
        {
            var query = new GetAllWarehousesQuery();

            return await _mediator.Send(query);
        }


    }

}
