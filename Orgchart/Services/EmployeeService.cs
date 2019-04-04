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

        public EmployeeTree GetEmployeeParent()
        {
            var employee = context.Employees
                .Where(x => x.ManagerId == null)
                .FirstOrDefault();
            GetEmployeeChildTree(employee);
            return employee;
        }

        private void GetEmployeeChildTree(EmployeeTree employee)
        {
            var employeeReporters = context.Employees
                .Where(x => x.ManagerId == employee.Id).ToList();

            if (employeeReporters.Count() > 0)
            {
                foreach (var reportersNode in employeeReporters)
                {
                    if (employee.Reporters == null)
                    {
                        employee.Reporters = new List<EmployeeTree>();
                        employee.Reporters.Add(reportersNode);
                    }
                    GetEmployeeChildTree(reportersNode);
                    employee.Reporters.Add(reportersNode);             
                }
            }
        }
    }
}
