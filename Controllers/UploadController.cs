using CRUD_Application_Asp.net_core_MVC.Data;
using CRUD_Application_Asp.net_core_MVC.Models;
using CRUD_Application_Asp.net_core_MVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace CRUD_Application_Asp.net_core_MVC.Controllers
{
    public class UploadController : Controller
    {
        private ApplicationContext _context;
        private readonly IHostingEnvironment _environment;

        public UploadController(ApplicationContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage(ImageCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var path = _environment.WebRootPath;
                var filePath = "Content/Image/" + model.ImagePath.FileName;
                var fullPath = Path.Combine(path, filePath);
                Uploadfile(model.ImagePath, fullPath);
                var data = new Image()
                {
                    Name = model.Name,
                    ImagePath = filePath
                };
                _context.Add(data);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public void Uploadfile(IFormFile file, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
        }

        public IActionResult Index()
        {
            var data = _context.Images.ToList();
            return View(data);
        }
    }
}
