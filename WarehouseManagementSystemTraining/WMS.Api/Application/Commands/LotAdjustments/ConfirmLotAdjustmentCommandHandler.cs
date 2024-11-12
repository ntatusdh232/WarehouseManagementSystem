using WMS.Domain.AggregateModels.LotAdjustmentAggregate;

namespace WMS.Api.Application.Commands.LotAdjustments
{
    public class ConfirmLotAdjustmentCommandHandler : IRequestHandler<ConfirmLotAdjustmentCommand,bool>
    {
        private readonly ILotAdjustmentRepository _lotAdjustmentRepository;

        public ConfirmLotAdjustmentCommandHandler(LotAdjustmentRepository lotAdjustmentRepository)
        {
            _lotAdjustmentRepository = lotAdjustmentRepository;
        }

        public async Task<bool> Handle(ConfirmLotAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var lotAdjustment = await _lotAdjustmentRepository.GetAdjustmentByLotId(request.LotId)
                ?? throw new EntityNotFoundException(nameof(LotAdjustment), request.LotId);

            lotAdjustment.Confirm(lotId: lotAdjustment.LotId,
                                  itemId: lotAdjustment.ItemId,
                                  beforeQuantity: lotAdjustment.BeforeQuantity,
                                  afterQuanity: lotAdjustment.AfterQuantity,
                                  unit: lotAdjustment.Unit,
                                  sublotAdjustments: lotAdjustment.SublotAdjustments
                                  );

            await _lotAdjustmentRepository.Update(lotAdjustment);

            return await _lotAdjustmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        }

    }
}
