using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AsthmaAQ.Client.Models
{
    public class AirQualityResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";

        [JsonPropertyName("data")]
        public AirQualityData Data { get; set; } = new AirQualityData();
    }

    public class AirQualityData
    {
        [JsonPropertyName("aqi")]
        public int AQI { get; set; }

        [JsonPropertyName("city")]
        public CityInfo City { get; set; } = new CityInfo();

        [JsonPropertyName("iaqi")]
        public Dictionary<string, IaqiValue> Iaqi { get; set; } = new();

        [JsonPropertyName("forecast")]
        public Forecast Forecast { get; set; } = new Forecast();
    }

    public class CityInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
    }

    public class IaqiValue
    {
        [JsonPropertyName("v")]
        public double Value { get; set; }
    }

    public class Forecast
    {
        [JsonPropertyName("daily")]
        public DailyForecast Daily { get; set; } = new DailyForecast();
    }

    public class DailyForecast
    {
        [JsonPropertyName("pm25")]
        public List<DailyValue> PM25 { get; set; } = new();

        [JsonPropertyName("pm10")]
        public List<DailyValue> PM10 { get; set; } = new();
    }

    public class DailyValue
    {
        [JsonPropertyName("day")]
        public string Day { get; set; } = "";

        [JsonPropertyName("avg")]
        public double Avg { get; set; }
    }
}
