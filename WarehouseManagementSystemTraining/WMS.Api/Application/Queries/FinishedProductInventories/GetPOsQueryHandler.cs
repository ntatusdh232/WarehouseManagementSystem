namespace WMS.Api.Application.Queries.FinishedProductInventories
{
    public class GetPOsQueryHandler : IRequestHandler<GetPOsQuery, IEnumerable<string>>
    {
        private readonly IMapper _mapper;
        private readonly IFinishedProductInventoryRepository _finishedProductInventoryRepository;

        public GetPOsQueryHandler(IMapper mapper, IFinishedProductInventoryRepository finishedProductInventoryRepository)
        {
            _mapper = mapper;
            _finishedProductInventoryRepository = finishedProductInventoryRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetPOsQuery request, CancellationToken cancellationToken)
        {
            var POs = await _finishedProductInventoryRepository.GetPos();

            return POs;

        }
    }
}
