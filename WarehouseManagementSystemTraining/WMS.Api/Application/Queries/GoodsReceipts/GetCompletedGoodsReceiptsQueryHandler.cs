﻿using WMS.Api.Application.Queries.GoodsIssues;
using WMS.Domain.AggregateModels.GoodsReceiptAggregate;

namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetCompletedGoodsReceiptsQueryHandler : IRequestHandler<GetCompletedGoodsReceiptsQuery, IEnumerable<GoodsReceiptViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;
        private readonly GoodsReceiptQuery goodsReceiptQuery;

        public GetCompletedGoodsReceiptsQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository, GoodsReceiptQuery goodsReceiptQuery)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
            this.goodsReceiptQuery = goodsReceiptQuery;
        }

        public async Task<IEnumerable<GoodsReceiptViewModel>> Handle(GetCompletedGoodsReceiptsQuery request, CancellationToken cancellationToken)
        {
            var completedGoodsReceipts = await goodsReceiptQuery._goodsReceipts
                .Where(g => g.Lots.All(lot => lot.ProductionDate != null
                                           && lot.ExpirationDate != null
                                           && lot.Sublots.Count > 0)
                         && g.Supplier != null)
                .ToListAsync();

            var goodsReceiptViewModel = _mapper.Map<IEnumerable<GoodsReceiptViewModel>>(completedGoodsReceipts);

            var newGoodsReceiptViewModel = await goodsReceiptQuery.Filter(goodsReceipts: goodsReceiptViewModel,
                                                                    goodsIssueLots: goodsReceiptQuery._goodsIssueLots);

            return newGoodsReceiptViewModel;

        }



    }
}
