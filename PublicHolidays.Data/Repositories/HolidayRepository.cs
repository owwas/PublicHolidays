using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PublicHolidays.Core.Models;
using PublicHolidays.Core.Repositories;
using PublicHolidays.Data.Repositories;

namespace PublicHolidays.Data.Repositories
{
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(PublicHolidaysDbContext context) 
            : base(context)
        { }
        //public async Task<IEnumerable<Holiday>> GetAllWithMusicsAsync()
        //{
        //    return await PublicHolidaysDbContext.Holidays
        //        .Include(a => a.Musics)
        //        .ToListAsync();
        //}

        //public Task<Holiday> GetWithMusicsByIdAsync(int id)
        //{
        //    return PublicHolidaysDbContext.Artists
        //        .Include(a => a.Musics)
        //        .SingleOrDefaultAsync(a => a.Id == id);
        //}

        private PublicHolidaysDbContext PublicHolidaysDbContext
        {
            get { return Context as PublicHolidaysDbContext; }
        }
    }
}