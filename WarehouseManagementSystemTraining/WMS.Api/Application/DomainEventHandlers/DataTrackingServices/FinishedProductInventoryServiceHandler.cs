namespace WMS.Api.Application.DomainEventHandlers.DataTrackingServices
{
    public class FinishedProductInventoryServiceHandler
    {
        private List<FinishedProductInventory> _productInventoryService;
        private readonly IFinishedProductInventoryRepository _finishedProductInventoryRepository;

        public FinishedProductInventoryServiceHandler(List<FinishedProductInventory> productInventoryService, IFinishedProductInventoryRepository finishedProductInventoryRepository)
        {
            _productInventoryService = productInventoryService;
            _finishedProductInventoryRepository = finishedProductInventoryRepository;
        }

        public void Add(FinishedProductInventory finishedProductInventory)
        {
            _finishedProductInventoryRepository.Add(finishedProductInventory);
        }

        public async Task<FinishedProductInventory?> GetInventory(string itemId, string unit, string purchaseOrderNumber)
        {
            var InventoryList =  await _finishedProductInventoryRepository.GetInventory(itemId, unit, purchaseOrderNumber);

            if (InventoryList == null)
            {
                throw new Exception("InventoryList is Null");
            }
            else
            {
                return InventoryList;
            }   

        }

    }
}
