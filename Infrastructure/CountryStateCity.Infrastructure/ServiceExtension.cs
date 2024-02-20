using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CountryStateCity.Infrastructure.Persistence;
using CountryStateCity.Application.Interfaces;
using CountryStateCity.Infrastructure.Repositories;
using CountryStateCity.Infrastructure.SeedData;

namespace CountryStateCity.Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var migrationAssembly = $"CountryStateCity.Infrastructure.SQLServer";
            services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b =>
                {
                    b.MigrationsAssembly(migrationAssembly);
                });
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddTransient<ISeedDataService, SeedDataService>();
            //services.AddTransient<IHttpClientHandler, Services.HttpClientHandler>();

            return services;
        }

    }
}
