using Application.Proyects.Command;
using Application.Proyects.Queries.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProyectService
    {
        void AddDeveloper(AddDevelopersToProyectCommand developer);

        List<Proyect> GetAll();
    }
}
