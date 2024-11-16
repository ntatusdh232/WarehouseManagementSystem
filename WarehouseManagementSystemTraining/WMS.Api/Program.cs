using WMS.Api.Application.Mapping;
using WMS.Api.Application.Queries.ItemLots;
using WMS.Api.Application.Queries.LotAdjustments;
using WMS.Domain.AggregateModels.DepartmentAggregate;
using WMS.Domain.AggregateModels.LotAdjustmentAggregate;

namespace WMS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options
                            .UseSqlServer(connectionString, b => b.MigrationsAssembly("WMS.Api")));

            builder.Services.AddAutoMapper(typeof(ModelToViewModelProfile));
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));


            // Register the repositories with scoped lifetime
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IItemClassRepository, ItemClassRepository>();
            builder.Services.AddScoped<IItemLotLocationRepository, ItemLotLocationRepository>();
            builder.Services.AddScoped<IItemLotRepository, ItemLotRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IGoodsReceiptRepository, GoodsReceiptRepository>();
            builder.Services.AddScoped<IGoodsIssueRepository, GoodsIssueRepository>();
            builder.Services.AddScoped<IGoodsIssueEntryRepository, GoodsIssueRepository>();
            builder.Services.AddScoped<IFinishedProductIssueRepository, FinishedProductIssueRepository>();
            builder.Services.AddScoped<IFinishedProductReceiptRepository, FinishedProductReceiptRepository>();
            builder.Services.AddScoped<IFinishedProductInventoryRepository, FinishedProductInventoryRepository>();
            builder.Services.AddScoped<IStorageRepository, StorageRepository>();
            builder.Services.AddScoped<IInventoryLogEntryRepository, InventoryLogEntryRepository>();
            builder.Services.AddScoped<IIsolatedItemLotRepository, IsolatedItemLotRepository>();
            builder.Services.AddScoped<ILotAdjustmentRepository, LotAdjustmentRepository>();

            builder.Services.AddScoped<LotAdjustmentQueries>();
            builder.Services.AddScoped<ItemLotsQueries>();
            builder.Services.AddScoped<GoodsReceiptQueries>();
            builder.Services.AddScoped<GoodsIssueQueries>();



            // Add MVC services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
