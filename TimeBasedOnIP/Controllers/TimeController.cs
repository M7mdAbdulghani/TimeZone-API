using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using TimeBasedOnIP.Helpers;

namespace TimeBasedOnIP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var publicIPAddress = GetPublicIPAddess();
            var timeZone = TimsZoneHelper.ConsumeTimeZoneApiAsync(publicIPAddress).Result;


            return new OkObjectResult(new
            {
                success = true,
                message = "Current DateTime and TimeZone",
                data = timeZone
            });
        }


        // Using "http://icanhazip.com" to Get Public IP Address
        private string GetPublicIPAddess()
        {
            string ipInString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
            return ipInString;
        }

    }
}
