using ECommerce.Models.Model.Products.States;
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
    public class SpecificationController:BaseController
    {
        private UserManager<Operator> _userManager;
        public SpecificationController(UserManager<Operator> userManager) : base(userManager)
        {
        }

        /// <summary>
        /// Group
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="state"></param>
        /// <returns></returns>
     
        public IActionResult GroupsList(int groupId, int? id, string title, State? state)
        {
            ViewBag.GroupId = groupId;

            return View();
        }

        public IActionResult AddGroup(int groupId)
        {
            ViewBag.Id = groupId;
            return View();
        }

        public IActionResult EditGroup(int id)
        {
            ViewBag.Id = id;
            return View("AddGroup");
        }

        public IActionResult DeleteGroup()
        {
            return RedirectToAction("list");
        }

        [HttpPost]
        public IActionResult SaveGroup(int? id,int? groupId,string title,State? state)
        {
            return RedirectToAction("List");
        }

        /// <summary>
        /// Specification Group
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="state"></param>
        /// <returns></returns>

        public IActionResult SGList(int id,string title,State state)
        {


            ViewBag.SPGroupId = id;
            return View();
        }

        public IActionResult Add(int sgid)
        {
            ViewBag.SGID = sgid;
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View("Add");
        }
    }
}
