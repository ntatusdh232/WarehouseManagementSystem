namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class AddLotsToGoodsIssueCommandHandler : IRequestHandler<AddLotsToGoodsIssueCommand, bool>
    {
        private readonly IGoodsIssueRepository _goodsIssueRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IItemLotRepository _itemLotRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IStorageRepository _storageRepository;

        public AddLotsToGoodsIssueCommandHandler(IGoodsIssueRepository goodsIssueRepository, IItemRepository itemRepository, IItemLotRepository itemLotRepository, IEmployeeRepository employeeRepository, IStorageRepository storageRepository)
        {
            _goodsIssueRepository = goodsIssueRepository;
            _itemRepository = itemRepository;
            _itemLotRepository = itemLotRepository;
            _employeeRepository = employeeRepository;
            _storageRepository = storageRepository;
        }

        public async Task<bool> Handle(AddLotsToGoodsIssueCommand request, CancellationToken cancellationToken)
        {
            var goodsIssue = await _goodsIssueRepository.GetGoodsIssueById(request.GoodsIssueId);

            if (goodsIssue == null)
            {
                throw new EntityNotFoundException(nameof(GoodsIssue), request.GoodsIssueId);
            }

            var newGoodsIssueLots = new List<CreateGoodsIssueLotViewModel>();
            var existingGoodsIssueLots = goodsIssue.Entries.SelectMany(entry => entry.Lots).ToList();

            foreach (var lot in request.GoodsIssueLots)
            {
                
                var existedLot = existingGoodsIssueLots.FirstOrDefault(s => s.GoodsIssueLotId == lot.GoodsIssueLotId);

                if (existedLot == null)
                {
                    newGoodsIssueLots.Add(lot);
                }

            }

            if (newGoodsIssueLots.Count == 0)
            {
                newGoodsIssueLots = request.GoodsIssueLots;
            }

            var dispatchedItemLots = new List<ItemLot>();

            foreach (var lotViewmodel in newGoodsIssueLots)
            {
                var employee = await _employeeRepository.GetEmployeeById(lotViewmodel.EmployeeId);
                if (employee == null)
                {
                    throw new EntityNotFoundException(nameof(Employee), lotViewmodel.EmployeeId);
                }

                var itemLot = await _itemLotRepository.GetItemLotById(lotViewmodel.GoodsIssueLotId);
                if (itemLot == null)
                {
                    throw new EntityNotFoundException(nameof(ItemLot), lotViewmodel.GoodsIssueLotId);
                }

                var quantity = lotViewmodel.ItemLotLocations.Sum(s => s.QuantityPerLocation);

                var NewGoodsIssueLots = await CreateGoodsIssueLotAsync(lotViewmodel, quantity, employee.EmployeeId, itemLot);
                goodsIssue.AddLot(itemLot.Item.ItemId, itemLot.Item.Unit, NewGoodsIssueLots);

                dispatchedItemLots.Add(itemLot);

            }

            foreach (var itemLot in dispatchedItemLots)
            {
                itemLot.Confirm(); // Hàm Confirm rỗng
            }

            // Cập nhật goodsIssue
            await _goodsIssueRepository.Update(goodsIssue);

            return await _goodsIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        private async Task<GoodsIssueLot> CreateGoodsIssueLotAsync(CreateGoodsIssueLotViewModel lotVM, double quantity,
                                                                   string employeeId, ItemLot itemLot)
        {
            List<GoodsIssueSublot> goodsIssueSublots = new();

            if (lotVM.ItemLotLocations is null)
            {
                throw new WarehouseDomainException($"You must enter location for itemlot.");
            }

            foreach (var sub in lotVM.ItemLotLocations)
            {
                var location = await _storageRepository.GetLocationsById(sub.Location.LocationId);
                if (location is null)
                {
                    throw new EntityNotFoundException($"Location does not exist, {sub.Location.LocationId}");
                }

                var isExistedLocation = itemLot.Locations.Find(ill => ill.LocationId == sub.Location.LocationId);
                if (isExistedLocation == null)
                {
                    throw new EntityNotFoundException($"Cannot found itemlot {itemLot.LotId} with locationId {sub.LocationId}");
                }

                GoodsIssueSublot sublot = new(sub.Location.LocationId, sub.QuantityPerLocation);
                goodsIssueSublots.Add(sublot);
            }

            GoodsIssueLot goodsIssueLot = new(goodsIssueLotId: lotVM.GoodsIssueLotId, 
                                              quantity: quantity, 
                                              note: lotVM.Note, 
                                              employeeId: employeeId, 
                                              sublots: goodsIssueSublots);

            return goodsIssueLot;
        }



    }






}
