namespace WMS.Api.Application.Commands.GoodsReceipts;

public class DeleteGoodsReceiptCommand : IRequest<bool>
{
    public string GoodsReceiptId { get; set; }

    public DeleteGoodsReceiptCommand(string goodsReceiptId)
    {
        GoodsReceiptId = goodsReceiptId;
    }
}
