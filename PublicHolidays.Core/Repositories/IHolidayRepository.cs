using System.Collections.Generic;
using System.Threading.Tasks;
using PublicHolidays.Core.Models;

namespace PublicHolidays.Core.Repositories
{
    public interface IHolidayRepository : IRepository<Holiday>
    {
        //Task<IEnumerable<Holiday>> GetAllWithMusicsAsync();
        //Task<Holiday> GetWithMusicsByIdAsync(int id);
    }
}