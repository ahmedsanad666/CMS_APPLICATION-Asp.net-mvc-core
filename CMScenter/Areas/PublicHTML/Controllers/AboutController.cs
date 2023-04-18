using Microsoft.AspNetCore.Mvc;

namespace CMScenter.Areas.PublicHTML.Controllers
{
    [Area("PublicHTML")]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
