namespace WMS.Api.Application.Commands.GoodsReceipts;

public class UpdateGoodsReceiptCommand : IRequest<bool>
{
    public string GoodsReceiptId { get; set; }
    public List<UpdateGoodsReceiptLotViewModel> GoodsReceiptLots {  get; set; }

    public UpdateGoodsReceiptCommand(string goodsReceiptId, List<UpdateGoodsReceiptLotViewModel> goodsReceiptLots)
    {
        GoodsReceiptId = goodsReceiptId;
        GoodsReceiptLots = goodsReceiptLots;
    }
}
