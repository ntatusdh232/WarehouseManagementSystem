namespace WMS.Api.Application.Commands.LotAdjustments;

public class RemoveLotAdjustmentCommand : IRequest<bool>
{
    public string LotId {  get; set; }

    public RemoveLotAdjustmentCommand(string lotId)
    {
        LotId = lotId;
    }
}
