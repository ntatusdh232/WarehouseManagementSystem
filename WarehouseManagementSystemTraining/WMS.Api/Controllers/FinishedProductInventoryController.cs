namespace WMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinishedProductInventoryController : ControllerBase
    {
        private readonly IFinishedProductInventoryRepository _repository;

        public FinishedProductInventoryController(IFinishedProductInventoryRepository repository)
        {
            _repository = repository;
        }
        private IActionResult HandleInternalError(Exception ex) =>
            StatusCode(500, $"Internal server error: {ex.Message}");

        [HttpGet("FinishedProductInventory/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var inventories = await _repository.GetAllFinishedProductInventory();
            return Ok(inventories);
        }

        [HttpPost("FinishedProductInventory/Add")]
        public async Task<IActionResult> Add([FromBody] FinishedProductInventory inventory)
        {
            if (inventory == null) return BadRequest("FinishedProductInventory data is required.");

            try
            {
                var addedInventory = await _repository.Add(inventory);
                return Ok(addedInventory);
            }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return HandleInternalError(ex); }
        }

        [HttpPut("FinishedProductInventory/Update/{inventoryId}")]
        public async Task<IActionResult> Update(
            string inventoryId, [FromBody] FinishedProductInventory inventory)
        {
            if (inventory == null) return BadRequest("FinishedProductInventory data is required.");

            try
            {
                var updatedInventory = await _repository.Update(inventory);
                return Ok(updatedInventory);
            }
            catch (ArgumentException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return HandleInternalError(ex); }
        }

        [HttpDelete("FinishedProductInventory/Remove/{inventoryId}")]
        public async Task<IActionResult> Remove(string inventoryId)
        {
            try
            {
                await _repository.Remove(inventoryId);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"FinishedProductInventory with ID {inventoryId} not found.");
            }
            catch (Exception ex) { return HandleInternalError(ex); }
        }
    }
}
