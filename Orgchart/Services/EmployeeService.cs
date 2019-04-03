using Microsoft.EntityFrameworkCore;
using Orgchart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgchart.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext context;

        public EmployeeService(EmployeeContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<EmployeeTree>> GetAllEmployees()
        {
            var employees = await context.Employees
                .Include(x => x.Reporters)
                .ToAsyncEnumerable().ToList();
            return employees;
        }
        public async Task<EmployeeTree> CreateEmployee(EmployeeTree employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<EmployeeTree> UpdateEmployee(EmployeeTree employee)
        {
            try
            {
                context.Employees.Update(employee);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return employee;
        }

        public async Task<EmployeeTree> GetEmployeeById(int? employeeId)
        {
            var employee = await context.Employees.FindAsync(employeeId);
            return employee;
        }

        public async Task<EmployeeTree> DeleteEmployee(int? employeeId)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return employee;
        }
    }
}
