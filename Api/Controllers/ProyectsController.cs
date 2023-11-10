using Api;
using Application.Developers.Queries;
using Application.Proyects.Command;
using Application.Proyects.Queries.Response;
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
        public async Task<IActionResult> AddDeveloperToProyect([FromBody] AddDevelopersToProyectCommand request, [FromRoute] int proyectId)
        {
            request.ProyectId = proyectId;
            return await Mediator.Send(request);
        }

        [HttpGet("{projectId}/developers")]
        public async Task<ActionResult<GetProyectResponse>> GetProyectById([FromQuery] GetProyectsRequest request)
        {
            GetProyectResponse response = await Mediator.Send(request);
            if (response is null)
            {
                return NotFound();
            }
            return await Mediator.Send(request);
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> Delete(DeleteProyectCommand request)
        {
            return await Mediator.Send(request);
        }


    }


}
