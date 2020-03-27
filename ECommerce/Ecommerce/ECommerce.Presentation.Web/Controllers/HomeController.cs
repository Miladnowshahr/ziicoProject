using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Web.Controllers
{
    [Route("Home")]
    public class HomeController:Controller
    {
        [Route("Index")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
