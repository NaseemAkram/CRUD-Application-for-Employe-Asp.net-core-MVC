using CRUD_Application_Asp.net_core_MVC.Data;
using CRUD_Application_Asp.net_core_MVC.Models.Account;
using CRUD_Application_Asp.net_core_MVC.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRUD_Application_Asp.net_core_MVC.Controllers.Account
{
    public class AccountController : Controller
    {
        private ApplicationContext _context;
        public AccountController(ApplicationContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LoginSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = _context.Users.Where(x => x.Username == model.Username).FirstOrDefault();
                if (data != null)
                {
                    bool isvalid = (data.Username == model.Username && data.Password == model.Password);
                    if (isvalid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Username) }, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                        HttpContext.Session.SetString("Username", model.Username);
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        TempData["error"] = "Invalid username or password";
                        return View(model);
                    }

                }
                else
                {
                    TempData["error"] = "user name is not valid";
                    return View(model);
                }
            }
            else
            {
                return View(model);

            }

        }

        //this is logout action method
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storecookies = Request.Cookies.Keys;
            foreach (var cookies in storecookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("LogIn", "Account");
        }




        [AcceptVerbs("Post", "Get")]
        public IActionResult UserNameIsExist(string username)
        {
            var data = _context.Users.Where(e => e.Username == username).SingleOrDefault();
            if (data != null)
            {
                return Json($"UserName{username} already in use");
            }
            else
            {
                return Json(true);
            }

        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new User()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Password = model.Password,
                    IsActive = model.IsActive
                };
                _context.Users.Add(data);
                _context.SaveChanges();
                TempData["successmessage"] = "You are eligile to login, please fill own creidential's then login";
                return RedirectToAction("LogIn");

            }
            else
            {
                TempData["error"] = "Empty form cannot be submitted";
                return View(model);
            }

        }
    }
}
