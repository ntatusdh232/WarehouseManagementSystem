using WMS.Domain.AggregateModels.GoodsReceiptAggregate;

namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetCompletedGoodsReceiptsQueryHandler : IRequestHandler<GetCompletedGoodsReceiptsQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public GetCompletedGoodsReceiptsQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetCompletedGoodsReceiptsQuery request, CancellationToken cancellationToken)
        {
            var goodsReceiptList = await _goodsReceiptRepository.GetCompletedGoodsReceipts();
            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(goodsReceiptList);
            return goodsReceiptViewModel;

        }
    }
}
