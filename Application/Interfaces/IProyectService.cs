using Application.Proyects.Queries.Response;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IProyectService
    {
        GetProyectResponse GetProyectById(int proyectId);

        IActionResult DeleteProyect(int proyectId);

    }
}
