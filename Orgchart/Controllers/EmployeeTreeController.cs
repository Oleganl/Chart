using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orgchart.Models;
using Orgchart.Services;

namespace Orgchart.Controllers
{
    public class EmployeeTreeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly EmployeeContext context;

        public EmployeeTreeController(IEmployeeService employeeService, EmployeeContext context)
        {
            this.employeeService = employeeService;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var employees = await employeeService.GetAllEmployees();

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(x => x.FirstName.Contains(searchString)
                || x.SecondName.Contains(searchString));
            }
            return View(employees);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeTree employeeTree)
        {
            try
            {
                await employeeService.CreateEmployee(employeeTree);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);   
            }
            catch(Exception)
            {
                return NotFound();
            }
           
            return View(employeeTree);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? employeeId)
        {
            var employee = await employeeService.GetEmployeeById(employeeId);
            if(employee == null)
            {
                return NotFound();
            }
            //ViewData["ManagerId"] = new SelectList(_context.employees, "Id", "Id", employee.ManagerId);
            ViewBag["ManagerId"] = new SelectList(context.Employees, employee.ManagerId);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeTree employeeTree)
        {
            try
            {
                await employeeService.UpdateEmployee(employeeTree);

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }
            catch(Exception)
            {
                return NotFound();
            }

            return View(employeeTree);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeTree = await employeeService.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
