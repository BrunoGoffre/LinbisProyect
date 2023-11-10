using Application.Developers.Queries.Response;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Application.Proyects.Command
{
    public class DeleteProyectCommand : IRequest<IActionResult>
    {
        public int ProyectId { get; set; }
    }

    public class DeleteProyectCommandHandler : IRequestHandler<DeleteProyectCommand, IActionResult>
    {
        private readonly IProyectService _service;
        public DeleteProyectCommandHandler(IProyectService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Handle(DeleteProyectCommand request, CancellationToken cancellationToken)
        {            
            try
            {
                return _service.DeleteProyect(request.ProyectId);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Failed trying to delete") { StatusCode = StatusCodes.Status500InternalServerError };
            }            
        }
    }
}
