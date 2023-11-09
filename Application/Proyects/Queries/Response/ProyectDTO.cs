using Application.Common.Mappings;
using Application.Developers.Queries.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proyects.Queries.Response
{
    public class ProyectDTO : IMapFrom<Proyect>
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset addedDate { get; set; }
        public int developmentCost { get; set; }
        public int effortRequireInDays { get; set; }
        public List<DeveloperDTO> ? Developers { get; set; }
    }
}
