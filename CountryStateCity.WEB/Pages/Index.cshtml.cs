using CountryStateCity.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CountryStateCity.WEB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public List<CountryViewModel> countryViewModels = new();
        public List<StateViewModel> stateViewModels = new();
        public List<CityViewModel> cityViewModels = new();
        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OnGet()
        {
            var client = _httpClientFactory.CreateClient("CountryApi");
            HttpResponseMessage response = await client.GetAsync("country");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                countryViewModels.AddRange(JsonConvert.DeserializeObject<List<CountryViewModel>>(responseBody));
            }
            return Page();
        }

        public async Task<IActionResult> OnGetGetStates(int countryId)
        {
            var client = _httpClientFactory.CreateClient("CountryApi");
            HttpResponseMessage response = await client.GetAsync($"state/{countryId}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                stateViewModels.AddRange(JsonConvert.DeserializeObject<List<StateViewModel>>(responseBody));
            }
            return Partial("_StateListPartial", stateViewModels);
        }

        public async Task<IActionResult> OnGetGetCities(int stateId)
        {
            var client = _httpClientFactory.CreateClient("CountryApi");
            HttpResponseMessage response = await client.GetAsync($"city/{stateId}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                cityViewModels.AddRange(JsonConvert.DeserializeObject<List<CityViewModel>>(responseBody));
            }
            return Partial("_CityListPartial", cityViewModels);
        }
    }
}