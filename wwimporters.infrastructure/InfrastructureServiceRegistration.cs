using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using wwimporters.infrastructure.Persistence;

namespace wwimporters.infrastructure
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WideWorldImportersContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("WWIConnectionString"),
                EF => EF.MigrationsAssembly(typeof(WideWorldImportersContext).Assembly.FullName).UseNetTopologySuite()));

            services.AddScoped<WideWorldImportersContextInitialiser>();

            return services;
        }

    }
}