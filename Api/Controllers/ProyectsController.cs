using Api;
using Application.Proyects.Command;
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

        [HttpPost("{proyectId}/developers")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IActionResult))]
        public async Task<IActionResult> AddDeveloperToProyect([FromBody] AddDevelopersToProyectCommand request, [FromRoute] int proyectId)
        {
            request.ProyectId = proyectId;
            return await Mediator.Send(request);
        }

        [HttpGet("{projectId}/developers")]
        public int Get()
        {
            return 0;
        }
        

    }


}
