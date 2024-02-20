using CountryStateCity.Application.Interfaces;
using CountryStateCity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountryStateCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        #region ===[ Private Members ]=============================================================

        private readonly ICityRepository _cityRepository;
        #endregion

        #region ===[ Constructor ]=================================================================
        public CityController(ICityRepository cityRepository)
        {
           this._cityRepository = cityRepository;
        }

        #endregion

        #region ===[ Action Methods ]=================================================================

        /// <summary>
        /// Get All City by State Id
        /// </summary>
        /// <param name="stateId">State Id</param>
        /// <returns>List Of Cities</returns>
        [HttpGet("{stateId}")]
        public async Task<IActionResult> GetAll(int stateId)
        {
            return Ok(await this._cityRepository.GetCityListByStateIdAsync(stateId));
        }

        #endregion
    }
}
