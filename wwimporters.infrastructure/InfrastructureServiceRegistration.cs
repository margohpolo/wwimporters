using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using wwimporters.infrastructure.Persistence.StoredProcedures.CustomMigrations;
using wwimporters.infrastructure.Persistence;

namespace wwimporters.infrastructure
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WideWorldImportersContext>(options => 
                options.UseSqlServer(
                    configuration.GetConnectionString("WWIConnectionString"),
                    EF => EF.MigrationsAssembly("wwimporters.efmigrations").UseNetTopologySuite()
                    )
                    .ReplaceService<IMigrator, CustomMigrator>()
                );

            services.AddScoped<WideWorldImportersContextInitialiser>();

            return services;
        }

    }
}