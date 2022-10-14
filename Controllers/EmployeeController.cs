using CRUD_Application_Asp.net_core_MVC.Data;
using CRUD_Application_Asp.net_core_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Application_Asp.net_core_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext _context;
        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            var result = _context.Employees.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name = model.Name,
                    City = model.City,
                    State = model.State,
                    Salary = model.Salary
                };
                _context.Employees.Add(emp);
                _context.SaveChanges();
                TempData["error"] = "Record Create Successfully";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "Empty field cannot submit";
                return View(model);
            }

        }

        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.FirstOrDefault(x => x.Id == id);
            _context.Employees.Remove(emp);

            _context.SaveChanges();
            TempData["error"] = "Record Delete Successfully";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var empp = _context.Employees.FirstOrDefault(x => x.Id == id);
            var result = new Employee()
            {
                Name = empp.Name,
                City = empp.City,
                Salary = empp.Salary,
                State = empp.State

            };
            return View(result);

        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var result = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                City = employee.City,
                Salary = employee.Salary,
                State = employee.State

            };
            _context.Employees.Update(result);
            _context.SaveChanges();
            TempData["error"] = "Record Edit Successfully";
            return RedirectToAction("Index");

        }

    }
}
