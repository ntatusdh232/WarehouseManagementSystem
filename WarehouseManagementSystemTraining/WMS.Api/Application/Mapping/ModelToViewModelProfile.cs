using WMS.Api.Application.Queries.ItemLots;
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
            MapFinishedProductIssueEntryViewModel();
            MapLocationViewModel();
            MapWarehouseViewModel();
            MapItemViewModel();
            MapGoodsReceiptLotViewModel();
            MapGoodsReceiptSublotViewModel();
            MapGoodsReceiptViewModel();
            MapItemLotViewModel();
            MapEmployeeViewModel();

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

        public void MapFinishedProductIssueEntryViewModel()
        {
            CreateMap<QueryResult<FinishedProductReceipt>, QueryResult<FinishedProductReceiptEntryViewModel>>();
            CreateMap<FinishedProductReceipt, FinishedProductReceiptEntryViewModel>();
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

        public void MapEmployeeViewModel()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<QueryResult<Employee>, QueryResult<EmployeeViewModel>>();
        }

    }
}
