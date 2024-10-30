namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetGoodsReceiptsByTimeQueryHandler : IRequestHandler<GetGoodsReceiptsByTimeQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public GetGoodsReceiptsByTimeQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetGoodsReceiptsByTimeQuery request, CancellationToken cancellationToken)
        {
            var goodsReceiptList = await _goodsReceiptRepository.GetGoodsReceiptsByTime(request.TimeTamp, request.IsCompleted);
            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(goodsReceiptList);
            return goodsReceiptViewModel;
        }
    }
}
