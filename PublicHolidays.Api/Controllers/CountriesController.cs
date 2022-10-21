using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicHolidays.Core.Models;
using PublicHolidays.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicHolidays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            IEnumerable<Country> countries = await _countryService.GetAllCountries();
            return Ok(countries);
        }
    }
}
