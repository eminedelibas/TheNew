using System.Threading.Tasks;
using CMS.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.Data.Concrete.EfCore
{
    public class Website3EContext : IdentityDbContext<ApplicationUser>
    {
        public Website3EContext(DbContextOptions<Website3EContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<Product> Products { get; set; }


    }
    
        
    
}
