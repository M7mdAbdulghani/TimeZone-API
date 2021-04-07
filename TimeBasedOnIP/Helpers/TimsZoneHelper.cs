using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using TimeBasedOnIP.Models;

namespace TimeBasedOnIP.Helpers
{
    public class TimsZoneHelper
    {
        public static async Task<TimeZone> ConsumeTimeZoneApiAsync(string ipAddress)
        {
            var timeZone = new TimeZone();
            string URL = "http://worldtimeapi.org/api/ip/" + ipAddress.ToString();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(URL))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    timeZone = JsonConvert.DeserializeObject<TimeZone>(apiResponse);
                }
            }
            return timeZone;
        }
    }
}
