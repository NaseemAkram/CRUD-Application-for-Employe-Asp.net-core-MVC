using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
namespace CRUD_Application_Asp.net_core_MVC.Models.ViewModel
{
    public class SignUpUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter user name")]
        [Display(Name = "User Name")]
        //[Remote(action: "UserNameIsExist", controller: "Account")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email id is required")]



        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter mobile number")]
        [Display(Name = "Mobile Number")]

        public long? Mobile { get; set; }
        [Required(ErrorMessage = "Please enter password")]


        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter confrom your password")]
        [Display(Name = "Confrom Password")]
        [Compare("Password", ErrorMessage = "Confrom cannot match")]
        public string ConfromPassword { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

    }
}
