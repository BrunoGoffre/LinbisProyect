using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Reflection;

namespace Database
{
    public class FileDevelopers : IFileDevelopers
    {
        private readonly IConfiguration _configuration;
        public FileDevelopers(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void AddDeveloper(Developer newDeveloper)
        {
            string path = _configuration.GetConnectionString("DevelopersLocalDatabase");
            List<Developer> objetList = this.GetAllData();
            
            string json;
            if (objetList is not null)
            {
                objetList.Add(newDeveloper);
                json = JsonConvert.SerializeObject(objetList, Formatting.Indented);

            }else
            {
                List<Developer> developers = new List<Developer> { newDeveloper } ;
                json = JsonConvert.SerializeObject(developers, Formatting.Indented);
            }

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(json);
            }
        }

        public List<Developer> GetDevelopersByProyectId(int proyectId)
        {
            List<Developer> developers = this.GetAllData();
            return developers.Where(d => d.ProyectId == proyectId).ToList();
        }

        private List<Developer> GetAllData()
        {
            string path = _configuration.GetConnectionString("DevelopersLocalDatabase");

            string readedJson;
            using (StreamReader sr = new StreamReader(path))
            {
                readedJson = sr.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<Developer>>(readedJson);
        }

    }
}