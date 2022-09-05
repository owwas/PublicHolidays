using System.Collections.Generic;
using System.Threading.Tasks;
using PublicHolidays.Core.Models;

namespace PublicHolidays.Core.Services
{
    public interface IHolidayService
    {
        Task<List<Holiday>> GetAllHolidays(string countryCode, int year);
        Task<Holiday> GetHolidayById(int id);
        Task<Holiday> CreateHoliday(Holiday newHoliday);
        Task UpdateHoliday(Holiday artistToBeUpdated, Holiday artist);
        Task DeleteHoliday(Holiday artist);
        Task<List<Country>> GetAllCountries();
    }
}