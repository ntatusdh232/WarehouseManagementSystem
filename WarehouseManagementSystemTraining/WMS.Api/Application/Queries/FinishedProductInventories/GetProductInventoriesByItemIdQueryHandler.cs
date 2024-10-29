namespace WMS.Api.Application.Queries.FinishedProductInventories
{
    public class GetProductInventoriesByItemIdQueryHandler : IRequestHandler<GetProductInventoriesByItemIdQuery, IEnumerable<FinishedProductInventoryViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IFinishedProductInventoryRepository _finishedProductInventoryRepository;

        public GetProductInventoriesByItemIdQueryHandler(IMapper mapper, IFinishedProductInventoryRepository finishedProductInventoryRepository)
        {
            _mapper = mapper;
            _finishedProductInventoryRepository = finishedProductInventoryRepository;
        }

        public async Task<IEnumerable<FinishedProductInventoryViewModel>> Handle (GetProductInventoriesByItemIdQuery request, CancellationToken cancellationToken)
        {
            var productInvetoryList = await _finishedProductInventoryRepository.GetProductInventoriesByItemId(request.ItemId, cancellationToken);
            var departmentViewModels = _mapper.Map<IEnumerable<FinishedProductInventoryViewModel>>(productInvetoryList);
            return departmentViewModels;

        }




    }
}
