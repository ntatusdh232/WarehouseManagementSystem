using System.ComponentModel.DataAnnotations.Schema;
using WMS.Domain.DomainEvents.LotAdjustmentEvents;

namespace WMS.Domain.AggregateModels.LotAdjustmentAggregate
{
    public class LotAdjustment : Entity, IAggregateRoot
    {
        public string LotId { get; set; }
        public double BeforeQuantity { get; set; }
        public double AfterQuantity { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsConfirmed { get; set; }
        public string Note { get; set; }
        public string Unit { get; set; }
        public Item Item { get; set; }
        public Employee Employee { get; set; }
        public string ItemId { get; set; }
        public string EmployeeId { get; set; }
        [NotMapped]
        public virtual List<SublotAdjustment> SublotAdjustments { get; set; }


#pragma warning disable CS8618
        private LotAdjustment() { }

        public LotAdjustment(string lotId, double beforeQuantity, double afterQuantity, bool isConfirmed, string note, 
                             Item item, Employee employee, string itemId, string employeeId)
        {
            LotId = lotId;
            BeforeQuantity = beforeQuantity;
            AfterQuantity = afterQuantity;
            IsConfirmed = isConfirmed;
            Note = note;
            Item = item;
            Employee = employee;
            ItemId = itemId;
            EmployeeId = employeeId;
        }

        public LotAdjustment(string lotId, string itemId, double afterQuantity, string note, Item item, Employee employee, string employeeId)
        {
            LotId = lotId;
            ItemId = itemId;
            AfterQuantity = afterQuantity;
            Note = note;
            Item = item;
            Employee = employee;
            EmployeeId = employeeId;
        }

#pragma warning restore CS8618

        public void Update(LotAdjustment lotAdjustment) 
        {
            BeforeQuantity = lotAdjustment.BeforeQuantity;
            AfterQuantity = lotAdjustment.AfterQuantity;
            IsConfirmed = lotAdjustment.IsConfirmed;
            Note = lotAdjustment.Note;
            Item = lotAdjustment.Item;
            Employee = lotAdjustment.Employee;
            ItemId = lotAdjustment.ItemId;
            EmployeeId = lotAdjustment.EmployeeId;
            SublotAdjustments = lotAdjustment.SublotAdjustments;
        }

        public void Update(double quantity)
        {
            AfterQuantity = quantity;
        }

        public void Confirm(string lotId, string itemId, double beforeQuantity, double afterQuanity, string unit, List<SublotAdjustment> sublotAdjustments)
        {
            IsConfirmed = true;
            Timestamp = DateTime.UtcNow.AddHours(7);
            AddDomainEvent(new LotAdjustedDomainEvent(lotId, itemId, beforeQuantity, afterQuanity, unit, Timestamp, sublotAdjustments));
        }
        public void AddSublot(string locationId, double beforeQuantity, double afterQuantity)
        {
            var sublot = new SublotAdjustment(locationId, beforeQuantity, afterQuantity);
            SublotAdjustments.Add(sublot);
        }
    }

}
