using CMScenter.Data;
using CMScenter.Views.Models;
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

        public VideoController(ApplicationDbContext db)
        {
                _db = db;
        }

        public async Task<IActionResult> Index(string id)
        {

            List<Video> videoList = _db.Videos.Where(u => u.VideoStatus == VideoStatus.Approved).Include(u => u.Contributor).Include(u => u.VideoCat).Take(6).ToList();

            
            NourViewModel viewModel = new NourViewModel()
            {
                videos = videoList,
        

            };
           
            // Your Vimeo API link

            string apiUrl = $"https://v1.nocodeapi.com/ahmedsanad99/vimeo/OnesUuHoiiMCkqfg/videoInfo?video_id={id}";

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

    }
}
