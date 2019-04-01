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

        public EmployeeTreeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = employeeService.GetAllEmployees();
            return View(employees);
        }

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

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeTree = await employeeService.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
