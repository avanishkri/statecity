using CountryStateCity.Application.Dtos;

namespace CountryStateCity.Application.Interfaces
{
    public interface ICityRepository 
    {
        Task<List<CityDto>> GetCityListByStateIdAsync(int stateID);
    }
}
