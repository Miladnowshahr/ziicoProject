using ECommerce.Models.Model.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController:BaseController
    {
        private UserManager<Operator> userManager;

        public AccountController(UserManager<Operator> userManager):base(userManager)
        {
            this.userManager = userManager;
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string username,string password,bool isRemmberMe)
        {
            return View();
        }

    }
}
