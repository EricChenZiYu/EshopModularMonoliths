
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Data.Interceptors;

namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Register services related to the Catalog module here
            // Example: services.AddScoped<ICatalogService, CatalogService>();

            // Add services to the container

            // Api Endpoint services 

            // Application use cases services
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // Data infrastructure services
            var connectionString = configuration.GetConnectionString("Database");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database connection string is not configured.");
            }

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<CatalogDbContext>((serviceProvider, options) =>
            {
                options.AddInterceptors(serviceProvider.GetServices<ISaveChangesInterceptor>());
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Catalog"));
            });
            services.AddScoped<IDataSeeder, CatalogDataSeeder>();
            return services;
        }

        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            // Configure middleware related to the Catalog module here
            // Example: app.UseMiddleware<CatalogMiddleware>();
            //InitialiseDatabaseAsync(app).GetAwaiter().GetResult();
            // 1. use api endpoint services

            // 2. use application use cases services

            // 3. use data infrastructure services
            app.UseMigration<CatalogDbContext>();

            return app;
        }

    }
}
