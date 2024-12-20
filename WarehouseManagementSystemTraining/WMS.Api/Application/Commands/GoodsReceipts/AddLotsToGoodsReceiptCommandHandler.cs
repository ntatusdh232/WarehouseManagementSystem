﻿namespace WMS.Api.Application.Commands.GoodsReceipts
{
    public class AddLotsToGoodsReceiptCommandHandler : IRequestHandler<AddLotsToGoodsReceiptCommand, bool>
    {
        private readonly IGoodsReceiptRepository _goodsReceiptRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AddLotsToGoodsReceiptCommandHandler(IGoodsReceiptRepository goodsReceiptRepository, IItemRepository itemRepository, 
                                                   IEmployeeRepository employeeRepository)
        {
            _goodsReceiptRepository = goodsReceiptRepository;
            _itemRepository = itemRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(AddLotsToGoodsReceiptCommand request, CancellationToken cancellationToken)
        {
            var goodsReceipt = await _goodsReceiptRepository.GetGoodsReceiptById(request.GoodsReceiptId)
                                   ?? throw new EntityNotFoundException(nameof(GoodsReceipt), request.GoodsReceiptId);

            var itemLots = new List<ItemLot>();

            foreach (var lot in request.GoodsReceiptLots)
            {
                var employee = await _employeeRepository.GetEmployeeById(lot.EmployeeId)
                    ?? throw new EntityNotFoundException(nameof(Employee), lot.EmployeeId);

                var item = await _itemRepository.GetItemById(lot.ItemId)
                    ?? throw new EntityNotFoundException(nameof(Item), lot.ItemId);

                var goodsReceiptLot = new GoodsReceiptLot(goodsReceiptLotId: lot.GoodsReceiptLotId,
                                                         quantity: lot.Quantity,
                                                         employee: employee,
                                                         item: item,
                                                         note: lot.Note,
                                                         goodsReceiptId: request.GoodsReceiptId
                                                         );

                var itemLot = new ItemLot(lotId: lot.GoodsReceiptLotId,
                                          quantity: lot.Quantity,
                                          timestamp: DateTime.Now,
                                          itemId: lot.ItemId);

                itemLots.Add(itemLot);

                goodsReceipt.AddLot(goodsReceiptLot);
            }

            var itemlot = new ItemLot();

            itemlot.Confirm(itemLots);

            await _goodsReceiptRepository.Update(goodsReceipt);

            return await _goodsReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);



        }




    }
}
