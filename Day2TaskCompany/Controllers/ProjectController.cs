﻿using Day2TaskCompany.Models;
using Day2TaskCompany.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Day2TaskCompany.Controllers
{
    public class ProjectController : Controller
    {
        CompanyDBContext DB;
        public ProjectController()
        {
            DB = new CompanyDBContext();
        }
        public IActionResult Index(int id, string entry)
        {
            // by department id 
            var q1 = DB.Projects.Where(D => D.department == id).ToList();
            ViewBag.id = id;
            ViewBag.entry = entry;
            return View("DeptProjects", q1);
        }

        //public IActionResult EditProjects(int id, int otherId)
        //{
            
        //    var DeptProjects = DB.Projects.Where(D => D.Number == otherId).ToList();


        //    ViewBag.DeptEmployees = DeptEmployees;
        //    return View("EditProjects", DeptProjects);
        //}

        public IActionResult AssignProjects(int id)
        {
            var DeptEmployees = DB.Employees.Where(D => D.DeptId == id).ToList();
            var DeptProjects = DB.Projects.Where(D => D.department == id).ToList();
            ViewBag.DeptEmployees = DeptEmployees;
            ViewBag.id = id;
            return View(DeptProjects);
        }

        public IActionResult AddProjects(List<int> id, List<int> secondId, int thirdId)
        {
            string entry = "";
            foreach(var item in id)
            {
                foreach(var element in secondId)
                {
                    var q1 = DB.WorksOnProjects.Where(D => D.EmpSSN == item && D.projNum == element).SingleOrDefault();
                    if (q1 == null)
                    {
                        WorksOnProject wop = new WorksOnProject();
                        wop.EmpSSN = item;
                        wop.projNum = element;
                        DB.WorksOnProjects.Add(wop);
                        DB.SaveChanges();
                    }
                    else
                    {
                        entry += $"Entry with ID ({item}) and Project Number ({element}) has been already added/n";
                    }
                }
            }
            
            
            return Index(thirdId,entry);
        }

        [HttpGet]
        public IActionResult AddSingleProject(int id)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AddSingleProject(ProjectVM project, int id)
        {
            string entry = "";
            if (ModelState.IsValid)
            {
                Project project1 = new Project()
                {
                    Name = project.Name,
                    Location = project.Location,
                    department = id
                };
                DB.Projects.Add(project1);
                DB.SaveChanges();
                return Index(id, entry);
            }

            return View();
        }
    }
}
