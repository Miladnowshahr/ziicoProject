using ECommerce.Models.Model.Users;
using Microsoft.AspNetCore.Http;
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
    public class GroupController : BaseController
    {
        private UserManager<Operator> _userManager;

        public GroupController(UserManager<Operator> userManager) : base(userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index(int id)
        {
            return View();
        }

        public IActionResult List(int? id,string title,string slug,byte state)
        {
            return View();
        }

        public IActionResult AddGroup()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View("AddGroup");
        }

        public IActionResult Save(int? id, string title, string slug, byte state, IFormFile photo)
        {
            return View();
        }
    }
}
