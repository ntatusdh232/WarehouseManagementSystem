using WMS.Domain.AggregateModels.DepartmentAggregate;

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

            // Register the unit of work with scoped lifetime
            builder.Services.AddScoped<IUnitOfWork, ApplicationDbContext>();

            // Register the repositories with scoped lifetime
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IFinishedProductInventoryRepository, FinishedProductInventoryRepository>();


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
