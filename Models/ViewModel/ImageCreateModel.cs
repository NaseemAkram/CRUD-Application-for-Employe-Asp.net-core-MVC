using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CRUD_Application_Asp.net_core_MVC.Models.ViewModel
{
    public class ImageCreateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please upload image")]
        [Display(Name = "Upload image")]
        public IFormFile ImagePath { get; set; }
    }
}
