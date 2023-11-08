using Microsoft.AspNetCore.Mvc;
using Controllers;
using Application.Proyects.Queries.Response;
using Application.Developers.Queries;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DevelopersController : ApiControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public DevelopersController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet({id})]
        //public async Task<ActionResult<GetDevelopersResponse>> GetDeveloperById([FromQuery] int id)
        //{
        //    return await Mediator.Send(request);
        //}
    }


}
