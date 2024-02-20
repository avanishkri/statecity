using AutoMapper;
using CountryStateCity.Application.Dtos;
using CountryStateCity.Application.Interfaces;
using CountryStateCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CountryStateCity.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration _configuration;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        #endregion

        #region ===[ Constructor ]=================================================================
        public CountryRepository(IConfiguration configuration, IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this._configuration = configuration;
            this._applicationDbContext = applicationDbContext;
            this._mapper = mapper;
        }


        #endregion

        #region ===[ IContactRepository Methods ]==================================================
        public async IAsyncEnumerable<Country> GetAllCountriesAsync()
        {
            await foreach (var entity in _applicationDbContext.Countries.AsAsyncEnumerable())
                {
                    yield return entity;
                }
        }

        public async Task<List<CountryDto>> GetAllCountries()
        {
            List<Country> countries = await _applicationDbContext.Countries.ToListAsync();
            return _mapper.Map<List<CountryDto>>(countries);
        }



        #endregion
    }
}
