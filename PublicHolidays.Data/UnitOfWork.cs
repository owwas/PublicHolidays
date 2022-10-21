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
        private CountryRepository _countryRepository;

        public UnitOfWork(PublicHolidaysDbContext context)
        {
            this._context = context;
        }

        public IHolidayRepository Holidays => _holidayRepository ??= new HolidayRepository(_context);

        public ICountryRepository Countries => _countryRepository ??= new CountryRepository(_context);

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