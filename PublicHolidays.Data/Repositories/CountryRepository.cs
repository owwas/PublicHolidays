using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PublicHolidays.Core.Models;
using PublicHolidays.Core.Repositories;
using PublicHolidays.Data.Repositories;

namespace PublicHolidays.Data.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(PublicHolidaysDbContext context) 
            : base(context)
        { }
        
        private PublicHolidaysDbContext PublicHolidaysDbContext
        {
            get { return Context as PublicHolidaysDbContext; }
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await PublicHolidaysDbContext.Countries
                .ToListAsync();
        }
    }
}