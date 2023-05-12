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

        public IActionResult Index(int catId)
        {

            List<Video> latestVideos = _db.Videos.OrderByDescending( u => u.Id).Where(u =>u.VideoStatus == VideoStatus.Approved).Take(6).Include(u => u.Contributor).Include(u=>u.VideoCat).ToList();
            List<Video> FeaturedVideos = _db.Videos.Where(u => u.IsFeatured == true).Where(u => u.VideoStatus == VideoStatus.Approved).Include(u => u.Contributor).ToList();
            if (catId == 0)
            {

            List<Video> videoList = _db.Videos.Where(u => u.VideoStatus == VideoStatus.Approved).Include(u => u.Contributor).Include(u => u.VideoCat).ToList();
            List<VideoCat> videoCtegories = _db.VideoCats.Take(4).ToList();
            NourViewModel viewModel = new NourViewModel()
            {
                videos = videoList,
                //videoIds = videoIds
                videoCtegories =    videoCtegories,
                latestVideos = latestVideos,
                FeaturedVideos= FeaturedVideos

            };
            return View(viewModel);
            }
            else
            {
                List<Video> videoListForCat = _db.Videos.Where(u => u.VideoStatus == VideoStatus.Approved).Where(u =>u.VideoCatId == catId).Include(u => u.Contributor).Include(u => u.VideoCat).ToList();

                List<VideoCat> videoCtegories = _db.VideoCats.Take(4).ToList();
                NourViewModel viewModel = new NourViewModel()
                {
                    videos = videoListForCat,
                    //videoIds = videoIds
                    videoCtegories = videoCtegories,
                      latestVideos = latestVideos,
                    FeaturedVideos = FeaturedVideos

                };
                return View(viewModel);
            }
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
