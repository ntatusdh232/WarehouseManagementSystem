﻿namespace WMS.Api.Application.Queries.FinishedProductIssues
{
    public class FinishedProductIssueEntryViewModel
    {
        public string PurchaseOrderNumber { get; set; }
        public double Quantity { get; set; }
        public string Note { get; set; }
        public string ItemId { get; set; }
        public ItemViewModel Item { get; set; }

        public FinishedProductIssueEntryViewModel(string purchaseOrderNumber, double quantity, string note, string itemId, ItemViewModel item)
        {
            PurchaseOrderNumber = purchaseOrderNumber;
            Quantity = quantity;
            Note = note;
            ItemId = itemId;
            Item = item;
        }
    }
}


