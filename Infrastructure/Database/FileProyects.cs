using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Database
{
    public class FileProyects : IFileProyects
    {
        private readonly IConfiguration _configuration;
        public FileProyects(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddProyect()
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteProyect(int proyectId)
        {
            List<Proyect> proyects = GetAllData();
            if (proyects != null)
            {
                int proyectToDelete = proyects.FindIndex(p => p.Id == proyectId);

                if (proyectToDelete != -1)
                {
                    proyects.RemoveAt(proyectToDelete);
                    OverwriteAll(proyects);
                    return new ObjectResult($"Deleted Succesfully ") { StatusCode = StatusCodes.Status204NoContent };
                }
            }
            return new ObjectResult($"Proyect not found ") { StatusCode = StatusCodes.Status404NotFound};
        }

        public List<Proyect> ReadAll()
        {
            return GetAllData();
        }

        private List<Proyect> GetAllData()
        {
            string path = _configuration.GetConnectionString("ProyectsLocalDatabase");

            string readedJson;
            using (StreamReader sr = new StreamReader(path))
            {
                readedJson = sr.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<Proyect>>(readedJson);
        }

        public Proyect? GetProyectById(int proyectId)
        {
            Proyect proyect = GetAllData().FirstOrDefault(p => p.Id == proyectId);
            return proyect != null ? proyect : null;
        }

        private bool OverwriteAll(List<Proyect> proyectList)
        {
            string path = _configuration.GetConnectionString("ProyectsLocalDatabase");
            string json;

            if (proyectList is not null)
            {
                json = JsonConvert.SerializeObject(proyectList, Formatting.Indented);
            }
            else
            {
                return false;
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(json);
            }

            return true;
        }

    }
}