using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AsthmaAQ.Client.Models;

namespace AsthmaAQ.Client.Services
{
    public class AirQualityService
    {
        private readonly HttpClient _http;
        private readonly string _token = "35f6c7d16652a7e1b0a73c0f69108420761fd840";

        public AirQualityService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AirQualityResponse?> GetAirQualityByCityAsync(string city)
        {
            try
            {
                var url = $"https://api.waqi.info/feed/{Uri.EscapeDataString(city)}/?token={_token}";
                return await _http.GetFromJsonAsync<AirQualityResponse>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching AQI: {ex.Message}");
                return null;
            }
        }
    }
}
