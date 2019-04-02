using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgchart.ViewModels
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }

        public string Fullname { get { return string.Format("{0} {1}", FirstName, FirstName); } }
    }
}
