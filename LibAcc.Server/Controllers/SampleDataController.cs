using Microsoft.AspNetCore.Mvc;

namespace LibAcc.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("[action]")]
        public void WeatherForecasts()
        {
        }
    }
}
