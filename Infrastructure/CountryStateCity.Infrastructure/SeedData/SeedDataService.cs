using CountryStateCity.Application.Interfaces;
using CountryStateCity.Domain.Entities;
using CountryStateCity.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace CountryStateCity.Infrastructure.SeedData
{

    public class SeedDataService : ISeedDataService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IServiceProvider _serviceProvider;
        public SeedDataService(IApplicationDbContext applicationDbContext, IServiceProvider serviceProvider)
        {
            this._applicationDbContext = applicationDbContext;
            this._serviceProvider = serviceProvider;
        }
        public async void SeedData(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!dbContext.Countries.Any()) { 

                var path = Path.Combine(Directory.GetCurrentDirectory(), "Data", "seeddata.json");
                var jsonData = File.ReadAllText(path);

                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new IgnorePropertyOnDeserializationResolver("Id"),
                    NullValueHandling = NullValueHandling.Ignore,
                };


                var countries = JsonConvert.DeserializeObject<List<Country>>(jsonData, settings);
                foreach (var country in countries)
                {
                    dbContext.Countries.Add(country);                
                }

                dbContext.SaveChanges();
            }


        }
    }

    public class IgnorePropertyOnDeserializationResolver : DefaultContractResolver
    {
        private readonly string _propertyNameToIgnore;

        public IgnorePropertyOnDeserializationResolver(string propertyNameToIgnore)
        {
            _propertyNameToIgnore = propertyNameToIgnore;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyName == _propertyNameToIgnore && property.Writable)
            {
                property.ShouldDeserialize = _ => false;
            }
            return property;
        }
    }
    
}
