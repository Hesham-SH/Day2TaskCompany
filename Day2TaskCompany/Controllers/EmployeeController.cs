using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Day2TaskCompany.Models;

namespace Day2TaskCompany.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyDBContext DB; 
        public EmployeeController()
        {
            DB = new CompanyDBContext();
        }
        public IActionResult Index()
        {
            List<Employee> employees = DB.Employees.ToList();
            return View("Index", employees);
        }

        public IActionResult GetById(int id)
        {
            
            Employee? employee = DB.Employees.Include(s => s.Supervisor).Where(e => e.SSN == id).SingleOrDefault();
;           if(employee == null)
                return View("Error");
            else
                return View(employee);
        }

        public IActionResult Add()
        {
           List<Employee> employees = DB.Employees.ToList();
           return View(employees);
        }

        public IActionResult AddEmployeeDb(Employee employee)
        {
            DB.Employees.Add(employee);
            DB.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Edit()
        //{

        //}
    }
}
