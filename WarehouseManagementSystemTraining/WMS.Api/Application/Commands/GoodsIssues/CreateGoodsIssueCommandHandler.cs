using WMS.Domain.AggregateModels.GoodsIssueAggregate;

namespace WMS.Api.Application.Commands.GoodsIssues;

public class CreateGoodsIssueCommandHandler : IRequestHandler<CreateGoodsIssueCommand, bool>
{
    private readonly IGoodsIssueRepository _goodsIssueRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IItemRepository _itemRepository;

    public CreateGoodsIssueCommandHandler(IGoodsIssueRepository goodsIssueRepository, IEmployeeRepository employeeRepository, IItemRepository itemRepository)
    {
        _goodsIssueRepository = goodsIssueRepository;
        _employeeRepository = employeeRepository;
        _itemRepository = itemRepository;
    }

    public async Task<bool> Handle(CreateGoodsIssueCommand request, CancellationToken cancellationToken)
    {
        var goodsIssue = await _goodsIssueRepository.GetGoodsIssueById(request.GoodsIssueId);
        if (goodsIssue != null)
        {
            throw new DuplicatedRecordException(nameof(GoodsIssue), request.GoodsIssueId);
        }
        var employee = await _employeeRepository.GetEmployeeById(request.EmployeeId);
        if (employee is null)
        {
            throw new EntityNotFoundException(nameof(Employee), request.EmployeeId);
        }
        var newGoodsIssue = new GoodsIssue(goodsIssueId: request.GoodsIssueId,
                                           receiver: request.Receiver,
                                           employeeId: request.EmployeeId);
        foreach (var entry in request.Entries)
        {
            var item = await _itemRepository.GetItemById(entry.ItemId);
            if (item is null)
            {
                throw new EntityNotFoundException(nameof(Item), entry.ItemId);
            }
            newGoodsIssue.AddEntry(item, entry.RequestedQuantity);
        }
        await _goodsIssueRepository.Add(newGoodsIssue, cancellationToken);

        return await _goodsIssueRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

    }
}
