using Api;
using Application.Proyects.Command;
using Application.Proyects.Command.Response;
using Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/proyects")]

    public class ProyectsController : ApiControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public ProyectsController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost("{projectId}/developers")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AddDevelopersToProyectResponse))]
        public async Task<ActionResult> AddDeveloperToProyect(AddDevelopersToProyectCommand request)
        {
            var proyectCreated = await Mediator.Send(request);
            return StatusCode(201, proyectCreated);
        }

        [HttpGet("{projectId}/developers")]
        public int Get()
        {
            return 0;
        }
        

    }


}
