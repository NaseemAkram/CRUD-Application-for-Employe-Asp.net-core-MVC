using CRUD_Application_Asp.net_core_MVC.Models;
using CRUD_Application_Asp.net_core_MVC.Models.Account;
using CRUD_Application_Asp.net_core_MVC.Models.Cascade;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application_Asp.net_core_MVC.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
