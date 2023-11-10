using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IFileProyects
    {
        List<Proyect> ReadAll();
        void AddProyect();

        public Proyect? GetProyectById(int proyectId);
        IActionResult DeleteProyect(int proyectId);
    }
}
