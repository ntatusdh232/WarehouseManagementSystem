namespace WMS.Api.Application.Commands.LotAdjustments;

public class CreateLotAdjustmentCommand : IRequest<bool>
{
    public string LotId {  get; set; }
    public string ItemId { get; set; }
    public double BeforeQuantity { get; set; }
    public double AfterQuantity {  get; set; }
    public string Unit {  get; set; }
    public string EmployeeName { get; set; }
    public string Note {  get; set; }
    public List<CreateSublotAdjustmentViewModel> SublotAdjustments { get; set; }

    public CreateLotAdjustmentCommand(string lotId, string itemId, double afterQuantity, double beforeQuantity, string unit, string employeeName, string note, List<CreateSublotAdjustmentViewModel> sublotAdjustments)
    {
        LotId = lotId;
        ItemId = itemId;
        AfterQuantity = afterQuantity;
        BeforeQuantity = beforeQuantity;
        Unit = unit;
        EmployeeName = employeeName;
        Note = note;
        SublotAdjustments = sublotAdjustments;
    }
}
