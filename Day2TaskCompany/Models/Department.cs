using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Day2TaskCompany.Models
{
    public class Department
    {
        [Key]
        public int Number { get; set; }
        public string? Name { get; set; }
        public virtual List<DepartmentLocation>? DepartmentLocations { get; set; }
        public virtual List<Project>? Projects { get; set; }

        //works
        public virtual List<Employee>? Employees { get; set; }
        public Employee? EmployeeManage { get; set; }

        //manages   
        [ForeignKey("EmployeeManage")]
        public int? EmpSSN { get; set; }

    }
}
