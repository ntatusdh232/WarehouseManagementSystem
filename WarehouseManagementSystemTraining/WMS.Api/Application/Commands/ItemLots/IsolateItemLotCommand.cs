namespace WMS.Api.Application.Commands.ItemLots;

public class IsolateItemLotCommand : IRequest<bool>
{
    public string ItemLotId { get; set; }
    public List<IsolatedItemSublotViewModel> IsolatedItemSublots { get; set; }

    public IsolateItemLotCommand(string itemLotId, List<IsolatedItemSublotViewModel> isolatedItemSublots)
    {
        ItemLotId = itemLotId;
        IsolatedItemSublots = isolatedItemSublots;
    }
}
