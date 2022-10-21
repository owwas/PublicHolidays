using Microsoft.AspNetCore.Mvc;
using PublicHolidays.Core.Models;
using PublicHolidays.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicHolidays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidaysController(IHolidayService holidayService)
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

        [HttpGet("GetSpecificDayStatus")]
        public async Task<IActionResult> GetSpecificDayStatus(string date, string countryCode)
        {
            string status = string.Empty;
            if (!string.IsNullOrEmpty(countryCode))
            {
                status = await _holidayService.GetSpecificDayStatus(date, countryCode);
            }

            return Ok(status);
        }

    }
}
