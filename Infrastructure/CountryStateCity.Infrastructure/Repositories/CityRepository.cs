using AutoMapper;
using CountryStateCity.Application.Dtos;
using CountryStateCity.Application.Interfaces;
using CountryStateCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CountryStateCity.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration _configuration;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        #endregion

        #region ===[ Constructor ]=================================================================
        public CityRepository(IConfiguration configuration, IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this._configuration = configuration;
            this._applicationDbContext = applicationDbContext;
            this._mapper = mapper;
        }

        #endregion

        public async Task<List<CityDto>> GetCityListByStateIdAsync(int stateID)
        {
            if(stateID == 0 )
            {
                throw new ArgumentException("State Id is required.");
            }
            List<City> cities = await this._applicationDbContext.Cities.Where(x => x.StateId.Equals(stateID)).ToListAsync();
            return _mapper.Map<List<CityDto>>(cities);
        }
    }
}
