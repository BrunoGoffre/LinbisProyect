using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFileDevelopers
    {
        void AddDeveloper(Developer newDeveloper);

        List<Developer> GetDevelopersByProyectId(int proyectId);
    }
}
