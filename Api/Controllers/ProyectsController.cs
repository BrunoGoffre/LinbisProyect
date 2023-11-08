using Api;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProyectsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public ProyectsController(ILogger<WeatherForecastController> logger)
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
