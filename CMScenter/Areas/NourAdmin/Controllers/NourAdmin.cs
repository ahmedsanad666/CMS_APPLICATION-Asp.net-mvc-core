using Microsoft.AspNetCore.Mvc;

namespace CMScenter.Areas.NourAdmin.Controllers
{
      
    [Area("NourAdmin")]
    public class NourAdmin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}



