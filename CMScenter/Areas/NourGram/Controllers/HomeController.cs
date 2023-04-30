using CMScenter.Areas.NourAdmin.Controllers;
using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CMScenter.Views.Models.Common;

namespace CMScenter.Areas.NourGram.Controllers
{
  [Area("NourGram")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;


        public HomeController(ApplicationDbContext db)
        {
            _db = db;            
        }

        public IActionResult Index()
        {

            List<Video> videoList = _db.Videos.Where(u => u.VideoStatus == VideoStatus.Approved).Include(u => u.Contributor).Include(u => u.VideoCat).ToList();

            NourViewModel viewModel = new NourViewModel()
            {
                videos = videoList,
                //videoIds = videoIds

            };
            return View(viewModel);
        }


        public string videoId(string link)
        {
            Uri uri = new Uri(link);
            string path = uri.AbsolutePath;

            // Get the video ID from the path
            string VideoId = path.Substring(1);
      
            return VideoId;
        }
    }
}
