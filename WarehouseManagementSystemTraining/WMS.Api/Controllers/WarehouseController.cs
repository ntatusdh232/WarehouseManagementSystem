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


    }

}
