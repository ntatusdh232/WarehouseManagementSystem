using WMS.Domain.AggregateModels.LotAdjustmentAggregate;
using WMS.Domain.AggregateModels.StorageAggregate;

namespace WMS.Api.Application.Mapping
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            MapDepartmentViewModel();

            MapFinishedProductInventoryViewModel();

            MapFinishedProductReceiptViewModel();
            MapFinishedProductReceiptEntryViewModel();

            MapFinishedProductIssueEntryViewModel();
            MapFinishedProductIssueViewModel();

            MapLocationViewModel();

            MapWarehouseViewModel();

            MapItemViewModel();
            MapItemLotViewModel();
            MapItemSublotViewModel();

            MapGoodsIssueViewModel();
            MapGoodsIssueEntryViewModel();
            MapGoodsIssueLotViewModel();
            MapGoodsIssueSubLotViewModel();

            MapGoodsReceiptLotViewModel();
            MapGoodsReceiptSublotViewModel();
            MapGoodsReceiptViewModel();

            MapEmployeeViewModel();

            MapLotAdjustmentViewModel();
            MapSublotAdjustmentViewModelViewModel();


        }

        public void MapDepartmentViewModel()
        {
            CreateMap<QueryResult<Department>, QueryResult<DepartmentViewModel>>();
            CreateMap<Department, DepartmentViewModel>();
        }

        public void MapFinishedProductInventoryViewModel()
        {
            CreateMap<QueryResult<FinishedProductInventory>, QueryResult<FinishedProductInventoryViewModel>>();
            CreateMap<FinishedProductInventory, FinishedProductInventoryViewModel>();
        }

        public void MapFinishedProductReceiptViewModel()
        {
            CreateMap<QueryResult<FinishedProductReceipt>, QueryResult<FinishedProductReceiptViewModel>>();
            CreateMap<FinishedProductReceipt, FinishedProductReceiptViewModel>();
        }
        public void MapFinishedProductReceiptEntryViewModel()
        {
            CreateMap<QueryResult<FinishedProductReceiptEntry>, QueryResult<FinishedProductReceiptEntryViewModel>>();
            CreateMap<FinishedProductReceiptEntry, FinishedProductReceiptEntryViewModel>();
        }


        public void MapFinishedProductIssueEntryViewModel()
        {
            CreateMap<QueryResult<FinishedProductIssueEntry>, QueryResult<FinishedProductIssueEntryViewModel>>();
            CreateMap<FinishedProductIssueEntry, FinishedProductIssueEntryViewModel>();
        }

        public void MapFinishedProductIssueViewModel()
        {
            CreateMap<QueryResult<FinishedProductIssue>, QueryResult<FinishedProductIssueViewModel>>();
            CreateMap<FinishedProductIssue, FinishedProductIssueViewModel>();
        }

        public void MapLocationViewModel()
        {
            CreateMap<QueryResult<Location>, QueryResult<LocationViewModel>>();
            CreateMap<Location, LocationViewModel>();
        }


        public void MapWarehouseViewModel()
        {
            CreateMap<QueryResult<Warehouse>, QueryResult<WarehouseViewModel>>();
            CreateMap<Warehouse, WarehouseViewModel>();
        }


        public void MapItemViewModel()
        {
            CreateMap<QueryResult<Item>, QueryResult<ItemViewModel>>();
            CreateMap<Item, ItemViewModel>();
        }

        public void MapGoodsReceiptViewModel()
        {
            CreateMap<QueryResult<GoodsReceipt>, QueryResult<GoodsReceiptViewModel>>();
            CreateMap<GoodsReceipt, GoodsReceiptViewModel>();
        }

        public void MapGoodsReceiptLotViewModel()
        {
            CreateMap<QueryResult<GoodsReceiptLot>, QueryResult<GoodsReceiptLotViewModel>>();
            CreateMap<GoodsReceiptLot, GoodsReceiptLotViewModel>();
        }

        public void MapGoodsReceiptSublotViewModel()
        {
            CreateMap<QueryResult<GoodsReceiptSublot>, QueryResult<GoodsReceiptSublotViewModel>>();
            CreateMap<GoodsReceiptSublot, GoodsReceiptSublotViewModel>();
        }

        public void MapItemLotViewModel()
        {
            CreateMap<QueryResult<ItemLot>, QueryResult<ItemLotViewModel>>();
            CreateMap<ItemLot, ItemLotViewModel>();
        }

        public void MapItemSublotViewModel()
        {
            CreateMap<QueryResult<ItemLotLocation>, QueryResult<ItemSublotViewModel>>();
            CreateMap<ItemLotLocation, ItemSublotViewModel>();
        }

        public void MapEmployeeViewModel()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<QueryResult<Employee>, QueryResult<EmployeeViewModel>>();
        }

        public void MapGoodsIssueViewModel()
        {
            CreateMap<QueryResult<GoodsIssue>, QueryResult<GoodsIssueViewModel>>();
            CreateMap<GoodsIssue, GoodsIssueViewModel>();
        }
        public void MapGoodsIssueEntryViewModel()
        {
            CreateMap<QueryResult<GoodsIssueEntry>, QueryResult<GoodsIssueEntryViewModel>>();
            CreateMap<GoodsIssueEntry, GoodsIssueEntryViewModel>();
        }
        public void MapGoodsIssueLotViewModel()
        {
            CreateMap<QueryResult<GoodsIssueLot>, QueryResult<GoodsIssueLotViewModel>>();
            CreateMap<GoodsIssueLot, GoodsIssueLotViewModel>();
        }
        public void MapGoodsIssueSubLotViewModel()
        {
            CreateMap<QueryResult<GoodsIssueSublot>, QueryResult<GoodsIssueSublotViewModel>>();
            CreateMap<GoodsIssueSublot, GoodsIssueSublotViewModel>();
        }

        public void MapLotAdjustmentViewModel()
        {
            CreateMap<QueryResult<LotAdjustment>, QueryResult<LotAdjustmentViewModel>>();
            CreateMap<LotAdjustment, LotAdjustmentViewModel>();
        }

        public void MapSublotAdjustmentViewModelViewModel()
        {
            CreateMap<QueryResult<SublotAdjustment>, QueryResult<SublotAdjustmentViewModel>>();
            CreateMap<SublotAdjustment, SublotAdjustmentViewModel>();
        }

    }
}
