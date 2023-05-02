using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NuGet.Configuration;

namespace CMScenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
      

        
        public AdminController(ApplicationDbContext db)
        {
            _db = db;                
        }


        public IActionResult Index()
        {
            // appsetttings last updated 
            AppSittings settings = _db.AppSittings.FirstOrDefault();


      int  teamCount = _db.TeamMembers.Count();

            ViewBag.teamCount = teamCount;
            var ViewModel = new ViewModel
            {
                appSettings = settings == null ? new AppSittings() : settings

            };

            return View(ViewModel);
        }
    }
}
