
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CRUD_Application_Asp.net_core_MVC.Models.Cascade
{
    public class Country
    {
        [Key]

        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
