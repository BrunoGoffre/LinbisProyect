using Application.Interfaces;
using Domain.Entities;
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

    }
}