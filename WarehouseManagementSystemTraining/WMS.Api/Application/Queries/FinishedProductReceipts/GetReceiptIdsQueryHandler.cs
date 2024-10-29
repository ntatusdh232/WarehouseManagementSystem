namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class GetReceiptIdsQueryHandler : IRequestHandler<GetReceiptIdsQuery, IEnumerable<string>>
    {
        private readonly IMapper _mapper;
        private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;

        public GetReceiptIdsQueryHandler(IMapper mapper, IFinishedProductReceiptRepository finishedProductReceiptRepository)
        {
            _mapper = mapper;
            _finishedProductReceiptRepository = finishedProductReceiptRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetReceiptIdsQuery request, CancellationToken cancellationToken)
        {
            var ReceiptIdsList = await _finishedProductReceiptRepository.GetReceiptIds();
            var finishedProductReceiptViewModel = _mapper.Map<IEnumerable<string>>(ReceiptIdsList);
            return finishedProductReceiptViewModel;

        }
    }
}
