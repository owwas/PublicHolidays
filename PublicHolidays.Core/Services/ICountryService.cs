using System.Collections.Generic;
using System.Threading.Tasks;
using PublicHolidays.Core.Models;

namespace PublicHolidays.Core.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountries();
    }
}