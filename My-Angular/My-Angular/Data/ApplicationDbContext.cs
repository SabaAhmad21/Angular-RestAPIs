using Microsoft.EntityFrameworkCore;
using My_Angular.Models.Domain;

namespace My_Angular.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
