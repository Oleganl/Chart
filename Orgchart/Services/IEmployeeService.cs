using Orgchart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgchart.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeTree>> GetAllEmployees();
        Task<EmployeeTree> CreateEmployee(EmployeeTree employee);
        Task<EmployeeTree> UpdateEmployee(EmployeeTree employee);
        Task<EmployeeTree> DeleteEmployee(int? employeeId);
        Task<EmployeeTree> GetEmployeeById(int? employeeId);
    }
}
