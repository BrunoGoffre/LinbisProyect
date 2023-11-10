using Application.Proyects.Command;
using Application.Proyects.Queries.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IProyectService
    {
        GetProyectResponse GetProyectById(int proyectId);

        IActionResult DeleteProyect(int proyectId);

    }
}
