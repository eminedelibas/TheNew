using System;
using System.Linq;
using CMS.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Data.Concrete.EfCore
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            Website3EContext context = app.ApplicationServices.GetRequiredService<Website3EContext>();

            context.Database.Migrate();

            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee() { Name = "Employee 1", Title = "Employee Description", Image = "1.jpg", Linkedln = "in" },
                    new Employee() { Name = "Employee 2", Title = "Employee Description", Image = "2.jpg", Linkedln = "in" },
                    new Employee() { Name = "Employee 3", Title = "Employee Description", Image = "3.jpg", Linkedln = "in" },
                    new Employee() { Name = "Employee 4", Title = "Employee Description", Image = "4.jpg", Linkedln = "in" }
                    );
                context.SaveChanges();
            }

            //if (!context.Users.Any())
            //{
            //    context.Users.AddRange(
            //        new User()
            //        {
            //            UserName = "User 1",Email = "user@gmail.com"
            //        }
            //    );
            //    context.SaveChanges();
            //}
        }
    }
}
