using System.ComponentModel.DataAnnotations;

namespace CRUD_Application_Asp.net_core_MVC.Models.ViewModel
{
    public class LoginSignUpViewModel
    {

        public string Username { get; set; }

        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool IsRemember { get; set; }

    }
}
