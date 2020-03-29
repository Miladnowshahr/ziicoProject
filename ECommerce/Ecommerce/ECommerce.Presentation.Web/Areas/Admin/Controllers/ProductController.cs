using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(int id, string PrimName)
        {
            return View();
        }
    }
}