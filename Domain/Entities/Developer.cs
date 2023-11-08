using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProyectId { get; set; }
        public DateTimeOffset addedDate { get; set; }
    }
}
//id: 5,
//name: "test developer name",
//projectId: 5,
//addedDate: 1573843210,
//costByDay: 700
