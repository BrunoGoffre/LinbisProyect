using Application.Proyects.Command;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IDevelopersService
    {
        IActionResult AddDeveloper(AddDevelopersToProyectCommand developer);
    }
}
