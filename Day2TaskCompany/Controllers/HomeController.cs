using Azure;
using Day2TaskCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Day2TaskCompany.Controllers
{
    public class HomeController : Controller
    {
        CompanyDBContext DB;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            DB = new CompanyDBContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Validate(userdata userInfo)
        {
            return View(userInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult ShowManagers()
        {
            //select from department
            //var q1 = DB.Employees.Include(D => DB.Departments).Where(D => D.department.EmpSSN == D.SSN).ToList();
            var q2 = DB.Departments.Include(D => D.EmployeeManage).Where(D => D.EmpSSN != null).Select(D => D.EmployeeManage).ToList();
            
            return View(q2);
        }
    }
}