namespace WMS.Api.Application.Commands.GoodsReceipts;

public class RemoveGoodsReceiptLotsCommand : IRequest<bool>
{
    public string GoodsReceiptId {  get; set; }
    public List<string> GoodsReceiptLotIds { get; set; }

    public RemoveGoodsReceiptLotsCommand(string goodsReceiptId, List<string> goodsReceiptLotIds)
    {
        GoodsReceiptId = goodsReceiptId;
        GoodsReceiptLotIds = goodsReceiptLotIds;
    }
}
