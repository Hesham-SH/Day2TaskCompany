using System.ComponentModel.DataAnnotations.Schema;

namespace Day2TaskCompany.Models
{
    public class WorksOnProject
    {
        //need composite PK of This 2 FK
        public string? Hours { get; set; }

        [ForeignKey("Employee")]
        public int? EmpSSN { get; set; }
        public virtual Employee? Employee { get; set; }

        [ForeignKey("Project")]
        public int? projNum { get; set; }
        public virtual Project? Project { get; set; }




    }
}
