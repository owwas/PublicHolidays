using PublicHolidays.Core;
using PublicHolidays.Core.Models;
using PublicHolidays.Core.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PublicHolidays.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpClient client;
        public HolidayService(IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient("PublicHolidaysApi");
        }

        public Task<Holiday> CreateHoliday(Holiday newHoliday)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHoliday(Holiday artist)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Holiday>> GetAllHolidays(string countryCode, int year)
        {
            var url = string.Format($"/enrico/json/v2.0?action=getHolidaysForYear&year={year}&country={countryCode}&holidayType=public_holiday");
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

            return result;
        }

        public Task<Holiday> GetHolidayById(int id)
        {
            throw new NotImplementedException();
        }

        //public Task UpdateHoliday(Holiday artistToBeUpdated, Holiday artist)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<Holiday>> GetHolidays(string countryCode, int year)
        //{
        //    var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
        //    var result = new List<HolidayModel>();
        //    var response = await client.GetAsync(url);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var stringResponse = await response.Content.ReadAsStringAsync();

        //        result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse,
        //            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        //    }
        //    else
        //    {
        //        throw new HttpRequestException(response.ReasonPhrase);
        //    }

        //    return result;
        //}

        public async Task<List<Country>> GetAllCountries()
        {
            var url = string.Format("/enrico/json/v2.0?action=getSupportedCountries");
            var response = await client.GetAsync(url);
            var result = new List<Country>();
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonSerializer.Deserialize<List<Country>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public Task UpdateHoliday(Holiday artistToBeUpdated, Holiday artist)
        {
            throw new NotImplementedException();
        }
    }
}
