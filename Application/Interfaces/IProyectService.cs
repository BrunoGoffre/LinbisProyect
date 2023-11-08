using Application.Proyects.Command;
using Application.Proyects.Queries.Response;

namespace Application.Interfaces
{
    public interface IProyectService
    {
        ProyectDTO AddDeveloper(AddDevelopersToProyectCommand developer);
    }
}
