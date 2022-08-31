using System;
using System.Threading.Tasks;
using PublicHolidays.Core.Repositories;

namespace PublicHolidays.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IHolidayRepository Holidays { get; }
        Task<int> CommitAsync();
    }
}