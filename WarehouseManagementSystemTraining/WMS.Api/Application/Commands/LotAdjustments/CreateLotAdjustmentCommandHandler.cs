
using WMS.Domain.AggregateModels.LotAdjustmentAggregate;

namespace WMS.Api.Application.Commands.LotAdjustments;

public class CreateLotAdjustmentCommandHandler : IRequestHandler<CreateLotAdjustmentCommand, bool>
{
    private readonly ILotAdjustmentRepository _lotAdjustmentRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IItemLotRepository _itemLotRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public CreateLotAdjustmentCommandHandler(ILotAdjustmentRepository lotAdjustmentRepository, IItemRepository itemRepository, IItemLotRepository itemLotRepository, IEmployeeRepository employeeRepository)
    {
        _lotAdjustmentRepository = lotAdjustmentRepository;
        _itemRepository = itemRepository;
        _itemLotRepository = itemLotRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<bool> Handle(CreateLotAdjustmentCommand request, CancellationToken cancellationToken)
    {
        var lotAdjustment = await _lotAdjustmentRepository.GetAdjustmentByLotId(request.LotId);
        if (lotAdjustment is not null)
        {
            throw new DuplicatedRecordException(nameof(LotAdjustment), request.LotId);
        }
        var item = await _itemRepository.GetItemByIdAndUnit(request.ItemId, request.Unit);
        if (item is null)
        {
            throw new EntityNotFoundException(nameof(Item), request.ItemId);
        }
        var itemLot = await _itemLotRepository.GetItemLotById(request.LotId);
        if (itemLot is null)
        {
            throw new EntityNotFoundException(nameof(ItemLot), request.LotId);
        }
        var employee = await _employeeRepository.GetEmployeeByName(request.EmployeeName);
        if (employee is null)
        {
            throw new EntityNotFoundException(nameof(Employee), request.EmployeeName);
        }
        var newLotAdjustment = new LotAdjustment(lotId: request.LotId,
                                                 itemId: request.ItemId,
                                                 afterQuantity: request.AfterQuantity,
                                                 note: request.Note,
                                                 item: item,
                                                 employee: employee,
                                                 employeeId: employee.EmployeeId);
        var totalQuantity = request.SublotAdjustments.Sum(s => s.NewQuantityPerLocation);
        if (totalQuantity != request.AfterQuantity)
        {
            throw new InvalidItemLotException("Total quantity of sublots does not match the specified AfterQuantity.");
        }
        newLotAdjustment.Update(request.AfterQuantity);
        foreach (var sublot in request.SublotAdjustments)
        {
            var existedSublot = itemLot.ItemLotLocations.Find(lot => lot.Location.LocationId == sublot.LocationId);

            if (existedSublot is null)
            {
                throw new EntityNotFoundException(nameof(ItemLotLocation), sublot.LocationId);
            }

            newLotAdjustment.AddSublot(locationId: sublot.LocationId,
                                       beforeQuantity: request.BeforeQuantity,
                                       afterQuantity: request.AfterQuantity);
        }
        await _lotAdjustmentRepository.Update(newLotAdjustment);

        return await _lotAdjustmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }
}
