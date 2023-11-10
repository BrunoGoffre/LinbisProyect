using Application.Developers.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Proyects.Queries.Response
{
    public class GetProyectResponse
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public long addedDate { get; set; }
        public int developmentCost { get; set; }
        public int effortRequireInDays { get; set; }
        public List<DeveloperDTO>? Developers { get; set; }
    }
}
