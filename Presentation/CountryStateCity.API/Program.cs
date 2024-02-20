using CountryStateCity.Application;
using CountryStateCity.Application.Interfaces;
using CountryStateCity.Infrastructure;
using CountryStateCity.Infrastructure.Persistence;
using CountryStateCity.API.Middleware;
using Microsoft.EntityFrameworkCore;

namespace CountryStateCity.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplicationLayer();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("CorsPolicy", opt => opt
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //migration
            using (var scope = app.Services.CreateScope())
            {
                
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
                {
                    var Seeder = scope.ServiceProvider.GetRequiredService<ISeedDataService>();
                    Seeder.SeedData(CancellationToken.None);
                }
            app.Run();
           
        }
    }
}