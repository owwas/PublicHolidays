using PublicHolidays.Core;
using PublicHolidays.Core.Models;
using PublicHolidays.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PublicHolidays.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpClient client;
        public HolidayService(IHttpClientFactory clientFactory, IUnitOfWork unitOfWork)
        {
            client = clientFactory.CreateClient("PublicHolidaysApi");
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Holiday>> GetAllHolidays(string countryCode, int year)
        {
            IEnumerable<Holiday> holidays = await _unitOfWork.Holidays.();

            var url = string.Format($"/enrico/json/v2.0?action=getHolidaysForYear&year={year}&country={countryCode}");
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                holidays = JsonSerializer.Deserialize<IEnumerable<Holiday>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                var groupedHolidays = holidays.GroupBy(x => x.date.month).Select(x => x.ToList()).ToList();

            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return holidays;
        }

        public async Task<List<Holiday>> GetAllHoliday2(string countryCode, int year)
        {
            var url = string.Format($"/enrico/json/v2.0?action=getHolidaysForYear&year={year}&country={countryCode}");
            var response = await client.GetAsync(url);
            var result = new List<Holiday>();
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<Holiday>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            var a = result.GroupBy(x => x.date.month).Select(x => x.ToList()).ToList();

            List<Holiday> ac = result.OrderBy(x => x.date).ToList();

            int count = 0;

            for (int i = 0; i < ac.Count; i++)
            {
                var count2 = 0;
                TimeSpan diff = (new DateTime(ac[i].date.year, ac[i].date.month, ac[i].date.day) - 
                    new DateTime(ac[i].date.year, ac[i].date.month, ac[i].date.day));

                if (diff.TotalDays == 1)
                {
                    count2 += 1;

                    if (count < count2)
                    {
                        count = count2;
                    }
                }
                else
                {
                    count2 = 0;
                }
            }

            return result;
        }

        public async Task<string> GetSpecificDayStatus(string date, string countryCode)
        {
            var url = string.Format($"/enrico/json/v2.0?action=isPublicHoliday&date={date}&country={countryCode}");
            HttpResponseMessage response = await client.GetAsync(url);

            string status = string.Empty;
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return status;
        }
    }
}
