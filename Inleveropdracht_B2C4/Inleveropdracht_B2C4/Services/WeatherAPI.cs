using Inleveropdracht_B2C4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Inleveropdracht_B2C4.Services
{
    public class WeatherAPI
    {
        public const string OPENWEATHERMAP_API_KEY = "d04f727c30a1c748915c767189439264";
        public const string BASE_URL = "https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units={2}&appid={3}";
        public static async Task<OneCallAPI> GetOneCallAPIAsync(double lat, double lon, string units)
        {
            OneCallAPI weather = new OneCallAPI();
            string url = String.Format(BASE_URL, lat, lon, units, OPENWEATHERMAP_API_KEY);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<OneCallAPI>(content);
                weather = posts;
            }
            return weather;
        }
    }
}
