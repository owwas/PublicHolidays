using AutoMapper;
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
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpClient _client;
        
        public CountryService(IHttpClientFactory clientFactory, IUnitOfWork unitOfWork)
        {
            _client = clientFactory.CreateClient("PublicHolidaysApi");
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            try
            {
                IEnumerable<Country> countries = await _unitOfWork.Countries.GetAllCountriesAsync();

                if (countries.Count() == 0)
                {
                    string url = string.Format("/enrico/json/v2.0?action=getSupportedCountries");
                    HttpResponseMessage response = await _client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string stringResponse = await response.Content.ReadAsStringAsync();
                        countries = JsonSerializer.Deserialize<IEnumerable<Country>>(stringResponse,
                            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                        await _unitOfWork.Countries.AddRangeAsync(countries);
                        await _unitOfWork.CommitAsync();
                    }
                    else
                    {
                        throw new HttpRequestException(response.ReasonPhrase);
                    }
                }
                return countries;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
