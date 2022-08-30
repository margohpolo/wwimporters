using Microsoft.OpenApi.Models;
using wwimporters.infrastructure;
using wwimporters.infrastructure.Persistence;

namespace wwimporters.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructureServices(Configuration);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {  Title = "WWImporters.API", Version = "v1" });
            });
            services.AddEndpointsApiExplorer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //TODO: Is there a cleaner way to handle seeding in Startup?
            #if DEBUG
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    try
                    {
                        var initialiser = scope.ServiceProvider.GetRequiredService<WideWorldImportersContextInitialiser>();
                        initialiser.Initialise();
                        initialiser.Seed();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred during database initialisation: {ex}");
                    }
                }
            #endif

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WWImporters.API v1"));
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}