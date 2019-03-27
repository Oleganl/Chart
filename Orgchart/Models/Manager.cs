using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgchart.Models
{
    public class Manager : Employee
    {
        public int ManagerId { get; set; }
        public ICollection<Reporter> Reporters { get; set; }
    }
}
