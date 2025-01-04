
using Azure.Core;
using System.Threading;
using WMS.Api.ErrorNotifications;

namespace WMS.Api.Application.Commands.FinishedProductReceipts
{
    public class CreateFinishedProductReceiptCommandHandler : IRequestHandler<CreateFinishedProductReceiptCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFinishedProductReceiptRepository _finishedProductReceiptRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ApplicationDbContext _context;

        public CreateFinishedProductReceiptCommandHandler(IEmployeeRepository employeeRepository, IFinishedProductReceiptRepository finishedProductReceiptRepository, 
                                                          IItemRepository itemRepository, ApplicationDbContext context)
        {
            _employeeRepository = employeeRepository;
            _finishedProductReceiptRepository = finishedProductReceiptRepository;
            _itemRepository = itemRepository;
            _context = context;
        }

        public async Task<bool> Handle(CreateFinishedProductReceiptCommand request, CancellationToken cancellationToken)
        {
            var finishedProductReceipt = await _finishedProductReceiptRepository.GetReceiptById(request.FinishedProductReceiptId);
            if (finishedProductReceipt is not null)
            {
                new DuplicatedRecordErrorDetail(nameof(FinishedProductReceipt), request.FinishedProductReceiptId);
            }

            var employee = await _employeeRepository.GetEmployeeById(request.EmployeeId);
            if (employee is null)
            {
                throw new EntityNotFoundException(nameof(Employee), request.EmployeeId);
            }

            var newReceipt = new FinishedProductReceipt(finishedProductReceiptId: request.FinishedProductReceiptId,
                                                         employeeId: request.EmployeeId);

            foreach (var entry in request.Entries)
            {
                var item = await _itemRepository.GetItemById(entry.ItemId);
                if (item == null)
                {
                    throw new EntityNotFoundException(nameof(Item), entry.ItemId);
                }

                var newEntry = new FinishedProductReceiptEntry(
                    purchaseOrderNumber: entry.PurchaseOrderNumber,
                    quantity: entry.Quantity,
                    note: entry.Note,
                    item: item,
                    itemId: item.ItemId
                );

                newReceipt.AddReceiptEntry(newEntry);
            }

            await _finishedProductReceiptRepository.Add(newReceipt);
            return await _finishedProductReceiptRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}