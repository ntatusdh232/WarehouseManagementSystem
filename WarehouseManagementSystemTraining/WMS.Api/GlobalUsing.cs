global using AutoMapper;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using System.Runtime.Serialization;
global using WMS.Api.Application.Commands.FinishedProductIssues.FinishedProductIssueViewModels;
global using WMS.Api.Application.Commands.GoodsIssues.GoodsIssueViewModels;
global using WMS.Api.Application.Commands.IsolatedItemLots.IsolatedItemLotViewModels;
global using WMS.Api.Application.Commands.Items.ItemViewModels;
global using WMS.Api.Application.Queries;
global using WMS.Api.Application.Queries.Departments;
global using WMS.Api.Application.Queries.Employees;
global using WMS.Api.Application.Queries.FinishedProductInventories;
global using WMS.Api.Application.Queries.FinishedProductReceipts;
global using WMS.Api.Application.Queries.GoodsIssues;
global using WMS.Api.Application.Queries.GoodsReceipts;
global using WMS.Api.Application.Queries.Items;
global using WMS.Api.Application.Queries.Warehouses;
global using WMS.Api.Exceptions;
global using WMS.Domain.AggregateModels.EmployeeAggregate;
global using WMS.Domain.AggregateModels.FinishedProductAggregate;
global using WMS.Domain.AggregateModels.FinishedProductAggregate.All_IFinishedProductsRepository;
global using WMS.Domain.AggregateModels.GoodsIssueAggregate;
global using WMS.Domain.AggregateModels.GoodsReceiptAggregate;
global using WMS.Domain.AggregateModels.InventoryLogEntryAggregate;
global using WMS.Domain.AggregateModels.IsolatedItemLotAggregate;
global using WMS.Domain.AggregateModels.ItemAggregate;
global using WMS.Domain.AggregateModels.ItemAggregate.All_IItemsRepository;
global using WMS.Domain.AggregateModels.ItemLotLocationAggregate;
global using WMS.Domain.AggregateModels.LocationAggregate;
global using WMS.Domain.AggregateModels.UserAggregate;
global using WMS.Domain.DomainEvents.FinishedProductIssueEvents;
global using WMS.Domain.DomainEvents.FinishedProductReceiptEvents;
global using WMS.Domain.DomainEvents.GoodsIssueEvents;
global using WMS.Domain.DomainEvents.GoodsReceiptEvents;
global using WMS.Domain.DomainEvents.IsolatedItemLotEvents;
global using WMS.Domain.DomainEvents.ItemLotEvents;
global using WMS.Domain.DomainEvents.LotAdjustmentEvents;
global using WMS.Domain.SeedWork;
global using WMS.Infrastructure;
global using WMS.Infrastructure.Repositories;




