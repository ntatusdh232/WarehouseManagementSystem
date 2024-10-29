namespace WMS.Api.Application.Queries.FinishedProductInventories
{
    public class FinishedProductInventoryViewModel
    {
        public string PurchaseOrderNumber { get; set; }
        public double Quality{ get; set; }
        public ItemViewModel itemViewModel { get; set; }
        public double NumOfPackets { get; set; }

        public FinishedProductInventoryViewModel(string purchaseOrderNumber, double quality, ItemViewModel itemViewModel, double numOfPackets)
        {
            PurchaseOrderNumber = purchaseOrderNumber;
            Quality = quality;
            this.itemViewModel = itemViewModel;
            NumOfPackets = numOfPackets;
        }
    }
}
