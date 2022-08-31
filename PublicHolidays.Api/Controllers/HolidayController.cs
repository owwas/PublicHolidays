using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicHolidays.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidaysApiService;

        public HolidayController(IHolidayService holidaysApiService)
        {
            _holidaysApiService = holidaysApiService;
        }

        public async Task<ActionResult<IEnumerable<HolidayModel>>> Index(string countryCode, int year)
        {
            List<HolidayModel> holidays = new List<HolidayModel>();

            if (!string.IsNullOrEmpty(countryCode) && year > 0)
            {
                holidays = await _holidaysApiService.GetHolidays(countryCode, year);
            }

            return Ok(holidays);
        }
    }
}
