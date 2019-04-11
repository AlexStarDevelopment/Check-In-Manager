// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using CheckInManager.BL;
//
//    var jsonString = "http://api.wunderground.com/api/37f4201157f6db0a/conditions/q/WI/Appleton.json"
//    var CurrentWeather = CWeather.FromJson(jsonString);
//    this.Temp = Convert.ToDecimal(CurrentWeather.CurrentObservation.TempF);
//    this.WeatherDesc = CurrentWeather.CurrentObservation.Weather;
//

namespace CheckInManager.BL
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CWeather
    {
        [JsonProperty("response")]
        public Response Response { get; set; }

        [JsonProperty("current_observation")]
        public CurrentObservation CurrentObservation { get; set; }
    }

    public partial class CurrentObservation
    {
        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("display_location")]
        public Dictionary<string, string> DisplayLocation { get; set; }

        [JsonProperty("observation_location")]
        public ObservationLocation ObservationLocation { get; set; }

        [JsonProperty("estimated")]
        public Estimated Estimated { get; set; }

        [JsonProperty("station_id")]
        public string StationId { get; set; }

        [JsonProperty("observation_time")]
        public string ObservationTime { get; set; }

        [JsonProperty("observation_time_rfc822")]
        public string ObservationTimeRfc822 { get; set; }

        [JsonProperty("observation_epoch")]
        public string ObservationEpoch { get; set; }

        [JsonProperty("local_time_rfc822")]
        public string LocalTimeRfc822 { get; set; }

        [JsonProperty("local_epoch")]
        public string LocalEpoch { get; set; }

        [JsonProperty("local_tz_short")]
        public string LocalTzShort { get; set; }

        [JsonProperty("local_tz_long")]
        public string LocalTzLong { get; set; }

        [JsonProperty("local_tz_offset")]
        public string LocalTzOffset { get; set; }

        [JsonProperty("weather")]
        public string Weather { get; set; }

        [JsonProperty("temperature_string")]
        public string TemperatureString { get; set; }

        [JsonProperty("temp_f")]
        public double TempF { get; set; }

        [JsonProperty("temp_c")]
        public double TempC { get; set; }

        [JsonProperty("relative_humidity")]
        public string RelativeHumidity { get; set; }

        [JsonProperty("wind_string")]
        public string WindString { get; set; }

        [JsonProperty("wind_dir")]
        public string WindDir { get; set; }

        [JsonProperty("wind_degrees")]
        public double WindDegrees { get; set; }

        [JsonProperty("wind_mph")]
        public double WindMph { get; set; }

        [JsonProperty("wind_gust_mph")]
        public double WindGustMph { get; set; }

        [JsonProperty("wind_kph")]
        public double WindKph { get; set; }

        [JsonProperty("wind_gust_kph")]
        public double WindGustKph { get; set; }

        [JsonProperty("pressure_mb")]
        public string PressureMb { get; set; }

        [JsonProperty("pressure_in")]
        public string PressureIn { get; set; }

        [JsonProperty("pressure_trend")]
        public string PressureTrend { get; set; }

        [JsonProperty("dewpoint_string")]
        public string DewpointString { get; set; }

        [JsonProperty("dewpoint_f")]
        public double DewpointF { get; set; }

        [JsonProperty("dewpoint_c")]
        public double DewpointC { get; set; }

        [JsonProperty("heat_index_string")]
        public string HeatIndexString { get; set; }

        [JsonProperty("heat_index_f")]
        public string HeatIndexF { get; set; }

        [JsonProperty("heat_index_c")]
        public string HeatIndexC { get; set; }

        [JsonProperty("windchill_string")]
        public string WindchillString { get; set; }

        [JsonProperty("windchill_f")]
        public string WindchillF { get; set; }

        [JsonProperty("windchill_c")]
        public string WindchillC { get; set; }

        [JsonProperty("feelslike_string")]
        public string FeelslikeString { get; set; }

        [JsonProperty("feelslike_f")]
        public string FeelslikeF { get; set; }

        [JsonProperty("feelslike_c")]
        public string FeelslikeC { get; set; }

        [JsonProperty("visibility_mi")]
        public string VisibilityMi { get; set; }

        [JsonProperty("visibility_km")]
        public string VisibilityKm { get; set; }

        [JsonProperty("solarradiation")]
        public string Solarradiation { get; set; }

        [JsonProperty("UV")]
        public string Uv { get; set; }

        [JsonProperty("precip_1hr_string")]
        public string Precip1HrString { get; set; }

        [JsonProperty("precip_1hr_in")]
        public string Precip1HrIn { get; set; }

        [JsonProperty("precip_1hr_metric")]
        public string Precip1HrMetric { get; set; }

        [JsonProperty("precip_today_string")]
        public string PrecipTodayString { get; set; }

        [JsonProperty("precip_today_in")]
        public string PrecipTodayIn { get; set; }

        [JsonProperty("precip_today_metric")]
        public string PrecipTodayMetric { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("forecast_url")]
        public string ForecastUrl { get; set; }

        [JsonProperty("history_url")]
        public string HistoryUrl { get; set; }

        [JsonProperty("ob_url")]
        public string ObUrl { get; set; }

        [JsonProperty("nowcast")]
        public string Nowcast { get; set; }
    }

    public partial class Estimated
    {
    }

    public partial class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public partial class ObservationLocation
    {
        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_iso3166")]
        public string CountryIso3166 { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("elevation")]
        public string Elevation { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("termsofService")]
        public string TermsofService { get; set; }

        [JsonProperty("features")]
        public Features Features { get; set; }
    }

    public partial class Features
    {
        [JsonProperty("conditions")]
        public long Conditions { get; set; }
    }

    public partial class CWeather
    {
        public static CWeather FromJson(string json) => JsonConvert.DeserializeObject<CWeather>(json, CheckInManager.BL.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CWeather self) => JsonConvert.SerializeObject(self, CheckInManager.BL.Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }


    /*
    * Another way to do this may be with:
    * 
    * using System.Web.Script.Serialization;  
    * using System.Web.Extensions;
    * 
    * var json = "http://api.wunderground.com/api/37f4201157f6db0a/conditions/q/WI/Appleton.json";
    * JavaScriptSerializer js = new JavaScriptSerializer();
    * dynamic CurrentWeather = js.Deserialize<dynamic>(json);
    * 
    * Then try to access the Weather and Temp_F tokens
    * It may take some experimentation to figure out under what names
    * they were deserialized.
    * 
    * this.Temp = Convert.ToDecimal(CurrentWeather.CurrentObservation.temp_F);
    * this.WeatherDescription = CurrentWeather.CurrentObservation.weather;    
    *  
    */
}

