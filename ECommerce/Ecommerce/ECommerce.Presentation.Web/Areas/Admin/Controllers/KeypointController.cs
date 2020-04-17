using ECommerce.Models.Model.KeyPoints;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KeypointController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(int productId, KeyPoint keyPoint) 
        {
            ViewBag.ProductId = productId;
            ViewBag.Keypoint = keyPoint;
            return View();
        }

        public IActionResult Add(int productId,KeyPointType type)
        {
            ViewBag.ProductId = productId;
            ViewBag.Type = type;
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Save(int? id,int? productId,KeyPointType? type ,string title )
        {
            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            return RedirectToAction("list");
        }

    }
}
