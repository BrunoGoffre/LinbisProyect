using Application.Proyects.Command;
using Application.Proyects.Queries.Response;

namespace Application.Interfaces
{
    public interface IProyectService
    {
        void AddDeveloper(AddDevelopersToProyectCommand developer);
    }
}
