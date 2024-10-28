namespace WMS.Api.Application.Commands.GoodsReceipts;

public class AddLotsToGoodsReceiptCommand : IRequest<bool>
{
    public string GoodsReceiptId {  get; set; }
    public List<CreateGoodsReceiptLotViewModel> GoodsReceiptLots { get; set; }

    public AddLotsToGoodsReceiptCommand(string goodsReceiptId, List<CreateGoodsReceiptLotViewModel> goodsReceiptLots)
    {
        GoodsReceiptId = goodsReceiptId;
        GoodsReceiptLots = goodsReceiptLots;
    }
}
