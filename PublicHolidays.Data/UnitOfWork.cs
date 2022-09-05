using System.Threading.Tasks;
using PublicHolidays.Core;
using PublicHolidays.Core.Repositories;
using PublicHolidays.Data.Repositories;

namespace PublicHolidays.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PublicHolidaysDbContext _context;
        private HolidayRepository _holidayRepository;

        public UnitOfWork(PublicHolidaysDbContext context)
        {
            this._context = context;
        }

        public IHolidayRepository Holidays => _holidayRepository = _holidayRepository ?? new HolidayRepository(_context);

        //public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}