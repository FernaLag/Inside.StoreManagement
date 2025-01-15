using FluentValidation;
using Inside.StoreManagement.Application.Behaviors;
using Inside.StoreManagement.Application.Features.Orders.Commands.Validators;
using Inside.StoreManagement.Application.Features.Orders.Queries.Handlers;
using Inside.StoreManagement.Application.Profiles;
using Inside.StoreManagement.Domain.Contracts;
using Inside.StoreManagement.Persistence.Repositories;
using Inside.StoreManagement.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Inside.StoreManagement.Persistence.Seeders;
using Microsoft.OpenApi.Models;
using Inside.StoreManagement.API.Configurations;

namespace Inside.StoreManagement.API
{
    public class Bootstrap
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterServices(services);
            RegisterRepositories(services);
            SetupDatabaseContext(services, configuration);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ListOrdersQueryHandler).Assembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddAutoMapper(typeof(OrderProfile).Assembly);

            services.AddValidatorsFromAssemblyContaining<AddProductToOrderCommandValidator>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.ParameterFilter<DefaultValueParameterFilter>();
                c.OperationFilter<DefaultValueOperationFilter>();
            });
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
        }

        private static void SetupDatabaseContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                    .ConfigureWarnings(warnings =>
                        warnings.Ignore(RelationalEventId.PendingModelChangesWarning))
                    .LogTo(Console.WriteLine));

            using var serviceProvider = services.BuildServiceProvider();
            DatabaseInitializer.Initialize(serviceProvider);
        }
    }
}