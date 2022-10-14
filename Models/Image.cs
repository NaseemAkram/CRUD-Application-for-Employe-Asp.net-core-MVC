using System.ComponentModel.DataAnnotations;

namespace CRUD_Application_Asp.net_core_MVC.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please choose file")]
        [Display(Name = "Choose Image")]
        public string ImagePath { get; set; }
    }
}
