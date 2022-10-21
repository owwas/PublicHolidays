using System.Collections.Generic;
using System.Threading.Tasks;
using PublicHolidays.Core.Models;

namespace PublicHolidays.Core.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
    }
}