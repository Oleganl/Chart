using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Orgchart.Models
{
    [Table("Employee")]
    public class EmployeeTree
    {
        public EmployeeTree()
        {
            Reporters = new List<EmployeeTree>();
        }
        public int Id { get; set; }
        public int? ManagerId { get; set; } 
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string SecondName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Position { get; set; }
        public string Phone { get; set; }

        public virtual EmployeeTree Manager { get; set; }
        public virtual List<EmployeeTree> Reporters { get; set; }
    }
}
