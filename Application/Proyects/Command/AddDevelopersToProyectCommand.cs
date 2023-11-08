using Application.Interfaces;
using Application.Proyects.Command.Response;
using MediatR;

namespace Application.Proyects.Command
{
    public class AddDevelopersToProyectCommand : IRequest<AddDevelopersToProyectResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset addedDate { get; set; }
    }

    public class AddDeveloperToProyectCommandHandler : IRequestHandler<AddDevelopersToProyectCommand, AddDevelopersToProyectResponse>
    {
        private readonly IProyectService _service;
        public AddDeveloperToProyectCommandHandler(IProyectService service)
        {
            _service = service;
        }

        public async Task<AddDevelopersToProyectResponse> Handle(AddDevelopersToProyectCommand request, CancellationToken cancellationToken)
        {
            var proyect = _service.AddDeveloper(request);
            //TOTO AddDevelopersToProyectResponse dto = Automaper.Map(...);
            return await Task.FromResult(new AddDevelopersToProyectResponse());
        }
    }
}
