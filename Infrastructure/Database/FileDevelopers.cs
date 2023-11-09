using Application.Interfaces;
using Domain.Entities;
using Newtonsoft.Json;
using System.Reflection;

namespace Database
{
    public class FileDevelopers : IFileDevelopers
    {
        public void AddDeveloper(Developer newDeveloper)
        {

            //TODO Terminar escritura de datos




            //string directorioEjecucion = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //// Combinar la ruta del directorio de ejecución con el nombre del archivo
            //string rutaCompleta = Path.Combine(directorioEjecucion, "Developers.json");

            //// Serializar el objeto a una cadena JSON
            //string json = JsonConvert.SerializeObject(newDeveloper, Formatting.Indented);

            //// Escribir la cadena JSON en un archivo sin File.WriteAllText
            //using (StreamWriter sw = new StreamWriter(rutaCompleta))
            //{
            //    sw.Write(json);
            //}
        }

        public void ReadAll()
        {
            throw new NotImplementedException();
        }

    }
}