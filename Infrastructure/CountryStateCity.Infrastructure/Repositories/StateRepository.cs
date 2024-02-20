using AutoMapper;
using CountryStateCity.Application.Dtos;
using CountryStateCity.Application.Interfaces;
using CountryStateCity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CountryStateCity.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration _configuration;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        #endregion

        #region ===[ Constructor ]=================================================================
        public StateRepository(IConfiguration configuration, IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this._configuration = configuration;
            this._applicationDbContext = applicationDbContext;
            this._mapper = mapper;
        }

        #endregion

        public async Task<List<StateDto>> GetStateListByCountryIdAsync(int countryId)
        {
            if(countryId == 0 )
            {
                throw new ArgumentException("Country Id is required.");
            }
            List<State> states = await this._applicationDbContext.States.Where(x => x.CountryId.Equals(countryId)).ToListAsync();
            return _mapper.Map<List<StateDto>>(states);
        }
    }
}
