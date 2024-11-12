using WMS.Domain.AggregateModels.LotAdjustmentAggregate;

namespace WMS.Api.Application.Commands.LotAdjustments
{
    public class RemoveLotAdjustmentCommandHandler : IRequestHandler<RemoveLotAdjustmentCommand, bool>
    {
        private readonly ILotAdjustmentRepository _lotAdjustmentRepository;

        public RemoveLotAdjustmentCommandHandler(ILotAdjustmentRepository lotAdjustmentRepository)
        {
            _lotAdjustmentRepository = lotAdjustmentRepository;
        }

        public async Task<bool> Handle(RemoveLotAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var lotAdjustment = await _lotAdjustmentRepository.GetAdjustmentByLotId(request.LotId)
                ?? throw new EntityNotFoundException(nameof(LotAdjustment), request.LotId);

            if (lotAdjustment.IsConfirmed == true)
            {
                throw new WarehouseDomainException(nameof(LotAdjustment));
            }

            await _lotAdjustmentRepository.Remove(lotAdjustment.LotId);

            return await _lotAdjustmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }


    }
}
