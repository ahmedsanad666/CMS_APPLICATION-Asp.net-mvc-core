
using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CMScenter.Areas.PublicHTML.Controllers
{
    [Area("PublicHTML")]
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
          
        }

        public IActionResult Index()
        {
            // get app settings data for db
            AppSittings settings = _db.AppSittings.FirstOrDefault(u => u.Id == 1);
            // get current language 

         
           

            int teamNumber = _db.TeamMembers.Count(); 
           List<TeamMember> teamMember = _db.TeamMembers.ToList();
            List<Services> services = _db.Services.Include(u => u.courseCategory).ToList();
            List<Posts> posts = _db.posts.Include(u => u.postsCategory).ToList();



            ViewData["teamNumber"] = teamNumber;
            var ViewModel = new ViewModel
            {
                appSettings = settings,
                TeamMember = teamMember,
                services = services,
                posts = posts,
                subMenu = _db.submenuBoxes.ToList()
            
            };
            return View(ViewModel);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}


        [HttpPost]
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) }
            );
            return LocalRedirect(returnUrl);
        }
        ///................................
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}