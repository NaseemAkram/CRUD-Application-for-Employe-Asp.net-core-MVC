using System.ComponentModel.DataAnnotations;

namespace CRUD_Application_Asp.net_core_MVC.Models
{
    public class Employee
    {
        [Key]

        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "City cannot be empty")]

        public string? City { get; set; }
        [Required(ErrorMessage = "State cannot be empty")]

        public string? State { get; set; }
        public decimal Salary { get; set; }
    }
}
