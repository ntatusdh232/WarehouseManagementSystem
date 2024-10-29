namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public GetAllQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var goodsReceiptList = await _goodsReceiptRepository.GetAllGoodsReceipts();
            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(goodsReceiptList);
            return goodsReceiptViewModel;

        }
    }
}
