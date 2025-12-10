namespace AsthmaAQ.Client.Utilities
{
    public enum AirQualityLevel
    {
        Good,
        Moderate,
        UnhealthySensitive,
        Unhealthy,
        VeryUnhealthy,
        Hazardous
    }

    public static class AqiAdvisor
    {
        public static AirQualityLevel FromPm25(double pm25)
        {
            return pm25 switch
            {
                <= 12 => AirQualityLevel.Good,
                <= 35.4 => AirQualityLevel.Moderate,
                <= 55.4 => AirQualityLevel.UnhealthySensitive,
                <= 150.4 => AirQualityLevel.Unhealthy,
                <= 250.4 => AirQualityLevel.VeryUnhealthy,
                _ => AirQualityLevel.Hazardous,
            };
        }

        public static string AdvisoryText(AirQualityLevel level)
        {
            return level switch
            {
                AirQualityLevel.Good => "Air quality is good. Enjoy your outdoor activities.",
                AirQualityLevel.Moderate => "Air quality is moderate. Sensitive groups should take precautions.",
                AirQualityLevel.UnhealthySensitive => "Unhealthy for sensitive groups. Asthmatics should limit prolonged outdoor exertion.",
                AirQualityLevel.Unhealthy => "Air quality is unhealthy. Everyone may experience health effects.",
                AirQualityLevel.VeryUnhealthy => "Air quality is very unhealthy. Avoid outdoor activities.",
                AirQualityLevel.Hazardous => "Hazardous air quality. Remain indoors and keep windows closed.",
                _ => "No advisory available."
            };
        }
    }
}
