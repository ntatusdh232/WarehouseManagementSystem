namespace WMS.Api.Application.Queries.GoodsReceipts
{
    public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, IList<string>>
    {
        private readonly IMapper _mapper;
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;

        public GetSuppliersQueryHandler(IMapper mapper, IGoodsReceiptRepository goodsReceiptRepository)
        {
            _mapper = mapper;
            _goodsReceiptRepository = goodsReceiptRepository;
        }

        public async Task<IList<string>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _goodsReceiptRepository.GetSuppliers();

            return suppliers;

        }




    }
}
