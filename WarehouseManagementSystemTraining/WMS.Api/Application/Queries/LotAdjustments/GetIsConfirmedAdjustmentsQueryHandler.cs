
namespace WMS.Api.Application.Queries.LotAdjustments
{
    public class GetIsConfirmedAdjustmentsQueryHandler : IRequestHandler<GetIsConfirmedAdjustmentsQuery, IEnumerable<LotAdjustmentViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly LotAdjustmentQueries lotAdjustmentQueries;

        public GetIsConfirmedAdjustmentsQueryHandler(IMapper mapper, LotAdjustmentQueries lotAdjustmentQueries)
        {
            _mapper = mapper;
            this.lotAdjustmentQueries = lotAdjustmentQueries;
        }


        public async Task<IEnumerable<LotAdjustmentViewModel>> Handle(GetIsConfirmedAdjustmentsQuery request, CancellationToken cancellationToken)
        {
            var confirmedAdjustments = await lotAdjustmentQueries._lotAdjustments
                .Where(s => s.IsConfirmed == request.IsConfirmed)
                .ToListAsync();

            var confirmedAdjustmentViewModels = _mapper.Map<IEnumerable<LotAdjustmentViewModel>>(confirmedAdjustments);

            return confirmedAdjustmentViewModels;
        }


    }
}


