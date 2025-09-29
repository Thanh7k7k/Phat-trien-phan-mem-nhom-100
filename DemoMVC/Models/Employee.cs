using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Employee : Person
    {
        [Required]
        public string EmployeeId { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}