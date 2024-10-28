namespace WMS.Api.Application.Commands.LotAdjustments;

public class ConfirmLotAdjustmentCommand : IRequest<bool>
{
   public string LotId { get; set; }

    public ConfirmLotAdjustmentCommand(string lotId)
    {
        LotId = lotId;
    }
}
