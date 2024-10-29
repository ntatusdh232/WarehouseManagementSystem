namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetUnCompletedGoodsReceiptsQueryHandler : IRequestHandler<GetUnCompletedGoodsReceiptsQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public GetUnCompletedGoodsReceiptsQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetUnCompletedGoodsReceiptsQuery request, CancellationToken cancellationToken)
        {
            var goodsReceiptList = await _goodsReceiptRepository.GetUnCompletedGoodsReceipts();
            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(goodsReceiptList);
            return goodsReceiptViewModel;

        }
    }
    
}
