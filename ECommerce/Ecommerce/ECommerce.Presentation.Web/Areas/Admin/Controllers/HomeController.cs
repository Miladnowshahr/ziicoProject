using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/[controller]/[action]")]
    //[Route("Admin")]
    //[Route("Admin/Home")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}