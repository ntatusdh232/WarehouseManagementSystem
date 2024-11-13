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

        }

        public void MapDepartmentViewModel()
        {
            CreateMap<QueryResult<Warehouse>, QueryResult<DepartmentViewModel>>();
            CreateMap<Warehouse, DepartmentViewModel>();
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
            CreateMap<QueryResult<WMS.Domain.AggregateModels.LocationAggregate.Location>, QueryResult<LocationViewModel>>();
            CreateMap<WMS.Domain.AggregateModels.LocationAggregate.Location, LocationViewModel>();
        }

        public void MapWarehouseViewModel()
        {
            CreateMap<QueryResult<Warehouse>, QueryResult<WarehouseViewModel>>();
            CreateMap<Warehouse, WarehouseViewModel>();
        }

        public void MapItemViewModel()
        {
            CreateMap<QueryResult<WMS.Domain.AggregateModels.ItemAggregate.Item>, QueryResult<ItemViewModel>>();
            CreateMap<WMS.Domain.AggregateModels.ItemAggregate.Item, ItemViewModel>();
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
    }
}
