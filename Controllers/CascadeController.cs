using CRUD_Application_Asp.net_core_MVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application_Asp.net_core_MVC.Controllers
{
    public class CascadeController : Controller
    {
        private ApplicationContext _context;
        public CascadeController(ApplicationContext context)
        {
            _context = context;

        }

        public JsonResult Country()
        {
            var cnt = _context.Countries.ToList();

            return new JsonResult(cnt);
        }
        public JsonResult State(int id)
        {
            var st = _context.States.Where(e => e.Country.Id == id).ToList();

            return new JsonResult(st);
        }
        public JsonResult City(int id)
        {
            var ct = _context.Cities.Where(i => i.State.Id == id).ToList();

            return new JsonResult(ct);
        }
        public IActionResult CascadeDropdown()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
