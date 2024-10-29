namespace WMS.Api.Application.Queries.FinishedProductReceipts
{
    public class GetByTimeQueryHandler : IRequestHandler<GetByTimeQuery, IEnumerable<FinishedProductReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;

        public GetByTimeQueryHandler(IMapper mapper, IFinishedProductReceiptRepository finishedProductReceiptRepository)
        {
            _mapper = mapper;
            _finishedProductReceiptRepository = finishedProductReceiptRepository;
        }

        public async Task<IEnumerable<FinishedProductReceiptViewModel>> Handle(GetByTimeQuery request, CancellationToken cancellationToken)
        {
            var ReceiptList = await _finishedProductReceiptRepository.GetReceiptByTime(request.TimeTamp);
            var finishedProductReceiptViewModel = _mapper.Map<IEnumerable<FinishedProductReceiptViewModel>>(ReceiptList);
            return finishedProductReceiptViewModel;

        }

    }
}
