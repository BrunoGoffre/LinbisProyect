using Application.Developers.Queries;
using Application.Proyects.Command;
using Application.Proyects.Queries.Response;
using Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/proyects")]

    public class ProyectsController : ApiControllerBase
    {
        public ProyectsController()
        {
        }

        [HttpPost("{proyectId}/developers")]        
        public async Task<IActionResult> AddDeveloperToProyect([FromBody] AddDevelopersToProyectCommand request, [FromRoute] int proyectId)
        {
            request.ProyectId = proyectId;
            return await Mediator.Send(request);
        }

        [HttpGet("{proyectId}/developers")]
        public async Task<ActionResult<GetProyectResponse>> GetProyectById([FromRoute] int proyectId)
        {
            var request = new GetProyectsRequest { ProyectId = proyectId };
            GetProyectResponse response = await Mediator.Send(request);
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("{proyectId}")]
        public async Task<IActionResult> Delete([FromRoute] int proyectId )
        {
            var request = new DeleteProyectCommand { ProyectId = proyectId };
            return await Mediator.Send(request);
        }


    }


}
