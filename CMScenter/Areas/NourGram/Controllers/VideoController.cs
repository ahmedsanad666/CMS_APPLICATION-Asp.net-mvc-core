using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using static CMScenter.Views.Models.Common;
using static System.Net.Mime.MediaTypeNames;

namespace CMScenter.Areas.NourGram.Controllers
{
    [Area("NourGram")]
    public class VideoController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public VideoController(ApplicationDbContext db , UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
                _db = db;
        }

        public async Task<IActionResult> Index(string id,int Db)
        {

            List<Video> videoList = _db.Videos.Where(u => u.VideoStatus == VideoStatus.Approved).Include(u => u.Contributor).Include(u => u.VideoCat).Take(6).ToList();
            Video videoDetails = _db.Videos.FirstOrDefault(u => u.Id == Db);
            //List<VideoComment> allComments = _db.VideoComments.Include(u => u.ApplicationUser).ToList();
            List<VideoComment> allComments = _db.VideoComments.Where(u => u.VideoId == Db).Include(u => u.ApplicationUser).ToList();


            VideoComment videoComment = new VideoComment();
            ViewBag.vimeoId = id;
            ViewBag.videoId = Db;

            NourViewModel viewModel = new NourViewModel()
            {
                videos = videoList,
                videItem = videoDetails,
                comment = videoComment,
                comments = allComments
              
        

            };

        // Your Vimeo API link
        
            string apiUrl = $"https://v1.nocodeapi.com/ahmedsanad996/vimeo/ABrRxAoIulbuMlVw/videoInfo?video_id={id}";

            // Your Vimeo API access token
            string accessToken = "62f69ef9cc32275b8af1677536b468cc";

            // Create a new instance of the HttpClient
            var httpClient = new HttpClient();

            // Set the Authorization header with your Vimeo access token
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("NourGramVideo", accessToken);

            // Make a GET request to the Vimeo API link
            var response = await httpClient.GetAsync(apiUrl);

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Parse the response content to a string   
                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to your desired model class

           var videoData  =   JsonConvert.DeserializeObject(responseContent);
                ViewBag.VideoData = videoData;

                // Return the video data to the view
                return View(viewModel);
            }
            else
            {
                // Return an error message if the response is not successful
                var errorMessage = $"Failed to retrieve video data. Status code: {response.StatusCode}";
                    ViewBag.ErrorMessage = errorMessage;
            }
                return View(viewModel);
        }


        public  IActionResult AddConmment(VideoComment obj, string UserId, int videoId, string VimeoId , string content)
        {

            obj.VideoId = videoId;
            obj.Content = content;
            obj.ApplicationUserId = UserId;
          _db.VideoComments.Add(obj);
         _db.SaveChanges();
            return RedirectToAction("Index","Video", new { id = VimeoId, Db = videoId });
        
            //return RedirectToAction("Index", "Video");
        }

    }
}
