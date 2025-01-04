using DocumentFormat.OpenXml.InkML;
using WMS.Domain.AggregateModels.LotAdjustmentAggregate;

namespace WMS.Api.Application.Commands.LotAdjustments
{
    public class RemoveLotAdjustmentCommandHandler : IRequestHandler<RemoveLotAdjustmentCommand, bool>
    {
        private readonly ILotAdjustmentRepository _lotAdjustmentRepository;
        private readonly ApplicationDbContext _context;

        public RemoveLotAdjustmentCommandHandler(ILotAdjustmentRepository lotAdjustmentRepository, ApplicationDbContext context)
        {
            _lotAdjustmentRepository = lotAdjustmentRepository;
            _context = context;
        }

        public async Task<bool> Handle(RemoveLotAdjustmentCommand request, CancellationToken cancellationToken)
        {
            var lotAdjustment = await _lotAdjustmentRepository.GetAdjustmentByLotId(request.LotId)
                ?? throw new EntityNotFoundException(nameof(LotAdjustment), request.LotId);

            var sublotAdjustments = _context.sublotAdjustments
                .Where(s => s.LotAdjustmentId == request.LotId)
                .ToList();


            if (lotAdjustment.IsConfirmed)
            {
                throw new WarehouseDomainException("Cannot delete a confirmed LotAdjustment.");
            }

            foreach (var sublot in sublotAdjustments)
            {
                _context.sublotAdjustments.Remove(sublot);
            }

            await _lotAdjustmentRepository.Remove(lotAdjustment.LotId);

            return await _lotAdjustmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }




    }



}
