global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using System.Runtime.Serialization;
global using WMS.Domain.AggregateModels.EmployeeAggregate;
global using WMS.Domain.AggregateModels.FinishedProductAggregate;
global using WMS.Domain.AggregateModels.FinishedProductAggregate.All_IFinishedProductsRepository;
global using WMS.Domain.AggregateModels.ItemAggregate;
global using WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository;
global using WMS.Domain.AggregateModels.LocationAggregate;
global using WMS.Domain.AggregateModels.UserAggregate;
global using WMS.Domain.AggregateModels.WarehouseAggregate;
global using WMS.Domain.SeedWork;
global using WMS.Infrastructure;
global using WMS.Infrastructure.Repositories;
global using WMS.Api.Application.Commands.FinishedProductIssues.FinishedProductIssueViewModels;
global using WMS.Api.Application.Commands.GoodsIssues.GoodsIssueViewModels;
global using WMS.Api.Application.Commands.IsolatedItemLots.IsolatedItemLotViewModels;
global using WMS.Domain.AggregateModels.GoodsIssueAggregate;
global using WMS.Api.Application.Commands.Items.ItemViewModels;




