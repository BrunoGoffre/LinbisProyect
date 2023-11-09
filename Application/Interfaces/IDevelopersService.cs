using Application.Proyects.Command;

namespace Application.Interfaces
{
    public interface IDevelopersService
    {
        void AddDeveloper(AddDevelopersToProyectCommand developer);
    }
}
