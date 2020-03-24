using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<Operator>
    {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
            
        }
    }
}
 