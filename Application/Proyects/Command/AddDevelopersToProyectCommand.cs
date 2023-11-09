using Application.Developers.Queries.Response;
using Application.Interfaces;
using Application.Proyects.Command.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Proyects.Command
{
    public class AddDevelopersToProyectCommand : IRequest<IActionResult>
    {
        public int ProyectId { get; set; }

        public DeveloperDTO Developer { get; set; }
    }

    public class AddDeveloperToProyectCommandHandler : IRequestHandler<AddDevelopersToProyectCommand, IActionResult>
    {
        private readonly IDevelopersService _service;
        public AddDeveloperToProyectCommandHandler(IDevelopersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Handle(AddDevelopersToProyectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _service.AddDeveloper(request);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"No se pudo crear el desarrollador") { StatusCode = 500 };
            }
            return new ObjectResult($"Creado Exitosamente") { StatusCode = 201 };
        }
    }
}
