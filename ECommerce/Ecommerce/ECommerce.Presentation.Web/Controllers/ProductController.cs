using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Web.Controllers
{
    public class ProductController:Controller
    {
        public IActionResult List(string keyword)
        {
            return View();
        }

        public IActionResult Index(int id)
        {
            return View();

        }
    }
}
