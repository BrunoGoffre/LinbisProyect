using Application.Developers.Queries.Response;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Application.Proyects.Command
{
    public class AddDevelopersToProyectCommand : IRequest<IActionResult>
    {
        [JsonIgnore]
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
                return _service.AddDeveloper(request);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Failed on developer creation ") { StatusCode = StatusCodes.Status500InternalServerError };
            }            
        }
    }
}
