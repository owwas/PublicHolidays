using PublicHolidays.Core;
using PublicHolidays.Core.Models;
using PublicHolidays.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublicHolidays.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HolidayService()
        {

        }

        public Task<Holiday> CreateHoliday(Holiday newHoliday)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHoliday(Holiday artist)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Holiday>> GetAllHolidays()
        {
            throw new NotImplementedException();
        }

        public Task<Holiday> GetHolidayById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHoliday(Holiday artistToBeUpdated, Holiday artist)
        {
            throw new NotImplementedException();
        }
    }
}
