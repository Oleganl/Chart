using System.Collections.Generic;

namespace Orgchart.ViewModels
{
    public class EmployeeViewModel
    {
        public int? ManagerId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public EmployeeViewModel Manager { get; set; }
        public ICollection<EmployeeViewModel> Reporters { get; set; }
    }
}
