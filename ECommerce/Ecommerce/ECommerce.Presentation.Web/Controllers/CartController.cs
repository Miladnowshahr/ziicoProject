using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Presentation.Web.Controllers
{
    public class CartController:Controller
    {
        public IActionResult Index(int? productItemId, int? count)
        {
            return View();
        }
        
    }
}
