using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;

namespace DemoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<HeThongPhanPhoi> HeThongPhanPhois { get; set; }
        public DbSet<DaiLy> DaiLys { get; set; }
    }
}