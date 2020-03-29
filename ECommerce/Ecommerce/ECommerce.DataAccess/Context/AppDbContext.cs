using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Models.Model.Products;
using ECommerce.Models.Model.Users;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models.Model.Products;
using ECommerce.Models.Model.Products.Brands;
using ECommerce.Models.Model.Products.Groups;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<Operator>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-RNVP9U0;database=DigiShopDB;Integrated Security=True;MultipleActiveResultSets=True");
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DbSet<Product> Products { get; set; }



        public static async Task CreateAdminAccount(IServiceProvider serviceProvider,IConfiguration configuration)
        {
            using ( var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {


                UserManager<Operator> userManager = serviceScope.ServiceProvider.GetService<UserManager<Operator>>();
                RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                string userName = configuration["Data:AdminUser:Name"];
                string email = configuration["Data:AdminUser:Email"];
                string passwrord = configuration["Data:AdminUser:Password"];
                string role = configuration["Data:AdminUser:Role"];

                if (await userManager.FindByNameAsync(userName) == null)
                {
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }

                    Operator user = new Operator
                    {
                        UserName = userName,
                        Email = email
                    };
                    IdentityResult result = await userManager.
                        CreateAsync(user, passwrord);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }


        }
    }
}
 