using Microsoft.AspNetCore.Mvc;
using PublicHolidays.Core.Models;
using PublicHolidays.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicHolidays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpGet("GetCountryHolidaysByYear")]
        public async Task<IActionResult> GetCountryHolidaysByYear(string countryCode, int year)
        {
            List<Holiday> holidays = new List<Holiday>();

            if (!string.IsNullOrEmpty(countryCode) && year > 0)
            {
                holidays = await _holidayService.GetAllHolidays(countryCode, year);
            }

            return Ok(holidays);
        }

        [HttpGet("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            List<Country> holidays = new List<Country>();

            holidays = await _holidayService.GetAllCountries();

            return Ok(holidays);
        }
    }
}
