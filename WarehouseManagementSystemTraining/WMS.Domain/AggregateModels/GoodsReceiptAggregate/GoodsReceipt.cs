using WMS.Domain.AggregateModels.ItemLotLocationAggregate;
using WMS.Domain.DomainEvents.GoodsReceiptEvents;

namespace WMS.Domain.AggregateModels.GoodsReceiptAggregate
{
    public class GoodsReceipt : Entity ,IAggregateRoot
    {
        public String GoodsReceiptId { get; set; }
        public String Supplier { get; set; }
        public DateTime Timestamp { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public List<GoodsReceiptLot> Lots { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GoodsReceipt() { }
        public GoodsReceipt(string goodsReceiptId, string supplier, string employeeId)
        {
            GoodsReceiptId = goodsReceiptId;
            Supplier = supplier;
            EmployeeId = employeeId;
        }
        public GoodsReceipt(string goodsReceiptId, string supplier, DateTime timestamp, 
                            Employee employee, string employeeId, List<GoodsReceiptLot> lots)
        {
            GoodsReceiptId = goodsReceiptId;
            Supplier = supplier;
            Timestamp = timestamp;
            Employee = employee;
            EmployeeId = employeeId;
            Lots = lots;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.




        public void Update(string lotId, double quantity, double sublotSize, 
                           string purchaseOrderNumber, Location location, 
                           DateTime productionDate, DateTime expirationDate )
        {

        }
        public void AddLot(GoodsReceiptLot goodsReceiptLot)
        {
            if (Lots == null)
            {
                new Exception("Not Found");
            }
            else
            {
                Lots.Add(goodsReceiptLot);
            }


        }
        public void RemoveLot(GoodsReceiptLot goodsReceiptLot)
        {
            if (goodsReceiptLot == null)
            {
                throw new WarehouseDomainException($"GoodsReceiptLot does not exist.");
            }
            Lots.Remove(goodsReceiptLot);
        }

        public void RemoveItemLotEntities(List<GoodsReceiptLot> lots)
        {
            AddDomainEvent(new RemoveItemLotsDomainEvent(lots));
        }


        public void Confirm()
        {

        }

        public void UpdateGoodsReceipt(String goodsReceiptId, String supplier, DateTime timestamp,
                                       Employee employee, List<GoodsReceiptLot> lots)
        {
            GoodsReceiptId = goodsReceiptId;
            Supplier = supplier;
            Timestamp = Timestamp;
            Employee = Employee;
            Lots = Lots;
        }
        public void RemoveItemLotEntities()
        {
            AddDomainEvent(new RemoveItemLotsDomainEvent(this.Lots));
        }

        public void UpdateLot(string oldLotId, string? newLotId, double quantity, List<GoodsReceiptSublot> sublots, DateTime? productionDate, DateTime? expirationDate, string? note)
        {
            string lotId = newLotId ?? oldLotId;
            var lot = Lots.Find(gr => gr.GoodsReceiptLotId == oldLotId);
            if (lot == null)
                throw new WarehouseDomainException($"GoodsReceiptLot with Id {lotId} does not exist.");

            lot.Update(lotId, quantity, productionDate, expirationDate, note, sublots);
        }

        public void UpdateItemLotEntity(string oldLotId, string? newLotId, List<ItemLotLocation>? itemLotLocations, double quantity, DateTime? productionDate, DateTime? expirationDate)
        {
            AddDomainEvent(new UpdateItemLotDomainEvent(oldLotId, newLotId, itemLotLocations, quantity, productionDate, expirationDate));
        }


    }
}
