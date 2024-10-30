using WMS.Api.Application.Mapping;

namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class FilterQueryHandler : IRequestHandler<FilterQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public FilterQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async  Task<IEnumerable<GoodsReceiptViewModel>> Handle (FilterQuery request, CancellationToken cancellationToken)
        {
            var goodsReceipts = _mapper.Map<IEnumerable<GoodsReceipt>>(request.goodsReceipts);
            var filterQueryList = await _goodsReceiptRepository.Filter(goodsReceipts, request.goodsReceiptLots);
            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(filterQueryList);
            return goodsReceiptViewModel;
        }
    }
}
