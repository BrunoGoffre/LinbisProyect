using Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DevelopersController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public DevelopersController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "")]
        public int Get()
        {
            return 0;
        }
    }


}
