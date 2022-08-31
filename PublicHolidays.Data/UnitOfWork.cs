using System.Threading.Tasks;
using PublicHolidays.Core;
using PublicHolidays.Core.Repositories;
using PublicHolidays.Data.Repositories;

namespace PublicHolidays.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PublicHolidaysDbContext _context;
        private MusicRepository _musicRepository;
        private HolidayRepository _artistRepository;

        public UnitOfWork(PublicHolidaysDbContext context)
        {
            this._context = context;
        }

        public IArtistRepository Artists => _artistRepository = _artistRepository ?? new HolidayRepository(_context);

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);

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