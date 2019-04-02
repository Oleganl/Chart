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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await employeeService.GetAllEmployees();
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

        public async Task<IActionResult> Tree()
        {
            List<EmployeeTree> tree = new List<EmployeeTree>();
            tree = await employeeService.GetAllEmployeeTree();
            return View(tree);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeTree = await employeeService.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
