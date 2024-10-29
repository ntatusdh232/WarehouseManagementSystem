namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetGoodsReceiptByIdQueryHandler : IRequestHandler<GetGoodsReceiptByIdQuery, QueryResult<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public GetGoodsReceiptByIdQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async Task<QueryResult<GoodsReceiptViewModel>> Handle(GetGoodsReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            var goodsReceiptList = await _goodsReceiptRepository.GetGoodsReceiptById(request.goodsReceiptId);
            var goodsReceiptViewModel = _mapper.Map<QueryResult<GoodsReceiptViewModel>>(goodsReceiptList);
            return goodsReceiptViewModel;

        }
    }
}
