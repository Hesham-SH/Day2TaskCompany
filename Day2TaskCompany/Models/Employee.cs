using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Day2TaskCompany.Models
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Minit { get; set; }
        public string? Sex { get; set; }
        public string? Address { get; set; }

        [Column(TypeName = "money")]
        public int? Salary { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        public virtual List<WorksOnProject>? WorksOnProjects { get; set; }

        public virtual List<Dependent> Dependents { get; set; }
        //works for
        [ForeignKey("department")]
        public int? DeptId{ get; set; }
        public Department? department{ get; set; }

        public Department? Deptmanage { get; set; }

        //FK => fluent API
        public int? SupervisorSSN { get; set; }
        public Employee? Supervisor { get; set; }
        public List<Employee>? Employees { get; set; }

    }
}
