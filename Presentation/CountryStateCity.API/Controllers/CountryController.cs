using CountryStateCity.Application.Interfaces;
using CountryStateCity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountryStateCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region ===[ Private Members ]=============================================================

        private readonly ICountryRepository _countryRepository;
        #endregion

        #region ===[ Constructor ]=================================================================
        public CountryController(ICountryRepository countryRepository)
        {
           this._countryRepository = countryRepository;
        }

        #endregion

        #region ===[ Action Methods ]=================================================================

        /// <summary>
        /// Get All Country List in Asynchronous/Stream chunks
        /// </summary>
        /// <returns>List Of Country</returns>
        [HttpGet]
        [Route("get-countires-aync")]
        public async IAsyncEnumerable<Country> GetAllAsync()
        {
            await foreach (var entity in this._countryRepository.GetAllCountriesAsync())
            {
                yield return entity;
            }
        }


        /// <summary>
        /// Get All Country List
        /// </summary>
        /// <returns>List Of Country</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           return Ok(await this._countryRepository.GetAllCountries());
            
        }

        #endregion
    }
}
