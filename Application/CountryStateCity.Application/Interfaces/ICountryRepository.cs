using CountryStateCity.Application.Dtos;
using CountryStateCity.Domain.Entities;

namespace CountryStateCity.Application.Interfaces
{
    public interface ICountryRepository 
    {
        IAsyncEnumerable<Country> GetAllCountriesAsync();
        Task<List<CountryDto>> GetAllCountries();
    }
}
