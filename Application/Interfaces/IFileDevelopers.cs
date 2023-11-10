using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Interfaces
{
    public interface IFileDevelopers
    {
        void ReadAll();
        void AddDeveloper(Developer newDeveloper);
    }
}
