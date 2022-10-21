using System.Collections.Generic;
using System.Threading.Tasks;
using PublicHolidays.Core.Models;

namespace PublicHolidays.Core.Services
{
    public interface IHolidayService
    {
        Task<IEnumerable<Holiday>> GetAllHolidays(string countryCode, int year);
        Task<string> GetSpecificDayStatus(string date, string countryCode);
    }
}