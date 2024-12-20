﻿namespace WMS.Api.Application.Queries.LotAdjustments
{
    public class LotAdjustmentViewModel
    {
        public string LotId { get; set; }
        public double BeforeQuantity { get; set; }
        public double AfterQuantity { get; set; }
        public DateTime Timestamp { get; set; }
        public ItemViewModel Item { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public string Note { get; set; }
        public List<SublotAdjustmentViewModel> SublotAdjustments { get; set; }

        public LotAdjustmentViewModel(string lotId, double beforeQuantity, double afterQuantity, DateTime timestamp, ItemViewModel item, EmployeeViewModel employee, string note, List<SublotAdjustmentViewModel> sublotAdjustments)
        {
            LotId = lotId;
            BeforeQuantity = beforeQuantity;
            AfterQuantity = afterQuantity;
            Timestamp = timestamp;
            Item = item;
            Employee = employee;
            Note = note;
            SublotAdjustments = sublotAdjustments;
        }
    }
}


