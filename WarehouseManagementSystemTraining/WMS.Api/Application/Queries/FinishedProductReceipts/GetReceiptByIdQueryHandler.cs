namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, QueryResult<FinishedProductReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;

        public GetReceiptByIdQueryHandler(IMapper mapper, IFinishedProductReceiptRepository finishedProductReceiptRepository)
        {
            _mapper = mapper;
            _finishedProductReceiptRepository = finishedProductReceiptRepository;
        }

        public async Task<QueryResult<FinishedProductReceiptViewModel>> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            var finishedProductReceiptList = await _finishedProductReceiptRepository.GetReceiptById(request.Id);
            var finishedProductReceiptViewModel = _mapper.Map<QueryResult<FinishedProductReceiptViewModel>>(finishedProductReceiptList);
            return finishedProductReceiptViewModel;

        }
    }
}
