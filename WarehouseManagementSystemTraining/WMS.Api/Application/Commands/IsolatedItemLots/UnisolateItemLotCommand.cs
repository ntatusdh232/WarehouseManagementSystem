namespace WMS.Api.Application.Commands.IsolatedItemLots
{
    public class UnisolateItemLotCommand : IRequest<bool>
    {
        public string ItemLotId { get; set; }
        public List<UnisolatedItemSublotViewModel> UnisolatedItemSublots { get; set; }

        public UnisolateItemLotCommand(string itemLotId, List<UnisolatedItemSublotViewModel> unisolatedItemSublots)
        {
            ItemLotId = itemLotId;
            UnisolatedItemSublots = unisolatedItemSublots;
        }
    }
}
