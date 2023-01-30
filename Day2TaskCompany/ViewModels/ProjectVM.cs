using System.ComponentModel.DataAnnotations;

namespace Day2TaskCompany.ViewModels
{
    public class ProjectVM
    {
        [MinLength(5, ErrorMessage = "Name Must Be At Least 5 Characters")]
        [RegularExpression("^[a-zA-Z]{5,15}")]
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        [Compare("Location")]
        public string? confirmLocation { get; set; }
    }
}

