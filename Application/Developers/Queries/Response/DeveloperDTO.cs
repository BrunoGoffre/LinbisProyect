using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Developers.Queries.Response
{
    public class DeveloperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public int ProyectId { get; set; }
        public long AddedDate { get; set; }
        public int costByDay { get; set; }
    }
}
