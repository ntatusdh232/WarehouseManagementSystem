namespace WMS.Api.Application.Commands.ItemLots;

public class RemoveItemLotCommand : IRequest<bool>
{
    public string ItemLotId { get; set; }

    public RemoveItemLotCommand(string itemLotId)
    {
        ItemLotId = itemLotId;
    }
}
