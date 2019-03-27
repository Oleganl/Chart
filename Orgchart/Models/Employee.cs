using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orgchart.Models
{
    public abstract class Employee
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
    }
}
