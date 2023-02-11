using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2TaskCompany.Models;
    public class ApplicationUser : IdentityUser
    {
    public string UserName { get; set; }
    public string EmailAddress { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public DateTime RegisterDate { get; set; }
    public string? Sex { get; set; }

    [Column(TypeName = "money")]
    public int? Salary { get; set; }

    [Column(TypeName = "date")]
    public DateTime? BirthDate { get; set; }

    public virtual List<WorksOnProject>? WorksOnProjects { get; set; }

    public virtual List<Dependent>? Dependents { get; set; }

    //FK => fluent API
    [ForeignKey("Supervisor")]
    public string? SupervisorSSN { get; set; }
    public virtual ApplicationUser? Supervisor { get; set; }
    public List<ApplicationUser>? Employees { get; set; }

    // NP for relation (manege 1 to 1) Employee => Department 
    public virtual Department? DepartmentManege { get; set; }

    // NP and Fk for relation (work 1 to m) Employee => Department 
    [ForeignKey("DepartmentWork")]
    public int? deptId { get; set; }
    public virtual Department? DepartmentWork { get; set; }


}

