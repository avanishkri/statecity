using CountryStateCity.Application.Interfaces;
using CountryStateCity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CountryStateCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        #region ===[ Private Members ]=============================================================

        private readonly IStateRepository _stateRepository;
        #endregion

        #region ===[ Constructor ]=================================================================
        public StateController(IStateRepository stateRepository)
        {
           this._stateRepository = stateRepository;
        }

        #endregion

        #region ===[ Action Methods ]=================================================================

        /// <summary>
        /// Get All State by Country Id
        /// </summary>
        /// <param name="countryId">Country Id</param>
        /// <returns>List Of States</returns>
        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetAll(int countryId)
        {
            return Ok(await this._stateRepository.GetStateListByCountryIdAsync(countryId));
        }

        #endregion
    }
}
