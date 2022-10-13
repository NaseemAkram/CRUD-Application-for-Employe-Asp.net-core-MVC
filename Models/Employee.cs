using System.ComponentModel.DataAnnotations;

namespace CRUD_Application_Asp.net_core_MVC.Models
{
    public class Employee
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal Salary { get; set; }
    }
}
