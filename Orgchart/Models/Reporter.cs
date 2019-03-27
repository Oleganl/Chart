using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgchart.Models
{
    public class Reporter : Employee
    {
        public int ReporterId { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
