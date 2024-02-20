using CountryStateCity.Application.Dtos;

namespace CountryStateCity.Application.Interfaces
{
    public interface IStateRepository 
    {
        Task<List<StateDto>> GetStateListByCountryIdAsync(int countryId);
    }
}
