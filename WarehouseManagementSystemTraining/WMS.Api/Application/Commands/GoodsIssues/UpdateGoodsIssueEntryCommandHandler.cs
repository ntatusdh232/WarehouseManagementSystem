using DocumentFormat.OpenXml.Vml.Office;
using WMS.Domain.AggregateModels.GoodsIssueAggregate;

namespace WMS.Api.Application.Commands.GoodsIssues
{
    public class UpdateGoodsIssueEntryCommandHandler : IRequestHandler<UpdateGoodsIssueEntryCommand,bool>
    {
        private readonly IGoodsIssueRepository _goodsIssueRepository;
        private readonly IItemRepository _itemRepository;

        public UpdateGoodsIssueEntryCommandHandler(IGoodsIssueRepository goodsIssueRepository, IItemRepository itemRepository)
        {
            _goodsIssueRepository = goodsIssueRepository;
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(UpdateGoodsIssueEntryCommand  request, CancellationToken cancellationToken)
        {
            var goodsIssue = await _goodsIssueRepository.GetGoodsIssueById(request.GoodsIssueId)
                                   ?? throw new ArgumentException("GoodsIssue not found.");

            var Entries = request.Entries;

            foreach (var entry in Entries)
            {
                var item = await _itemRepository.GetItemById(entry.ItemId)
                           ?? throw new ArgumentException("Item not found.");
                var newEntries = goodsIssue.Entries.Select(s => CreateNewGoodsIssueEntry(s, entry, item) ).ToList();
                goodsIssue.MergeEntries(newEntries);
            }

            await _goodsIssueRepository.Update(goodsIssue, cancellationToken);

            return true;
        }

        private GoodsIssueEntry CreateNewGoodsIssueEntry(GoodsIssueEntry existingEntry, UpdateGoodsIssueEntryViewModel entry, Item item)
        {
            var newitem = new Item
            {
                ItemType = item.ItemType,
                ItemId = item.ItemId,
                ItemName = item.ItemName,
                Unit = entry.Unit,
                MinimumStockLevel = item.MinimumStockLevel,
                Price = item.Price,
                PacketSize = item.PacketSize,
                PacketUnit = item.PacketUnit,
                ItemClasses = item.ItemClasses
            };

            return new GoodsIssueEntry
            (
                existingEntry.GoodsIssueEntryId,
                entry.RequestedQuantity,
                newitem,
                existingEntry.Item.ItemId
            );
        }

    }
}
