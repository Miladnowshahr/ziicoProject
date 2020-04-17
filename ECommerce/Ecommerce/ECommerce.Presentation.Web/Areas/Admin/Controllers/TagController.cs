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
    public class TagController:BaseController
    {
        private UserManager<Operator> _userManager;

        public TagController(UserManager<Operator> userManager):base(userManager)
        {
            _userManager = userManager;
        }

        public IActionResult List(string title,State? state)
        {
            return View();
        }

        public IActionResult Add(int id)
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View("Add");
        }

        public IActionResult Save(int? id, string title,State state)
        {
            return RedirectToAction("list");
        }

        /// <summary>
        /// لیست مقادیر یک بر چسب
        /// </summary>
        /// <returns></returns>
        public IActionResult Values(int id,string title,State? state)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// add value in a tag
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        public IActionResult AddValue(int tagId)
        {
            ViewBag.TagId = tagId;
            return View();
        }
        

        /// <summary>
        /// edit tag value with a id of value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditValue(int id )
        {
            ViewBag.Id = id;
            return View("AddValue");
        }

        [HttpPost]
        public IActionResult SaveValue(int? id,int? tagId, string title, State state)
        {
            return RedirectToAction("values");
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction("Values");
        }
    }
}
