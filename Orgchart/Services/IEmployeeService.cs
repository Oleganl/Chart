using Orgchart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgchart.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeTree> CreateEmployee(EmployeeTree employee);
        Task<EmployeeTree> UpdateEmployee(int? employeeId);
        Task<EmployeeTree> DeleteEmployee(int? employeeId);
        Task<IEnumerable<EmployeeTree>> GetAllEmployees();
    }
}
