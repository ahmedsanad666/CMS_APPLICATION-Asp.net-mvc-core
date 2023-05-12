using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.EntityFrameworkCore;

namespace CMScenter.Areas.NourAdmin.Controllers
{
      
    [Area("NourAdmin")]
    public class NourAdmin : Controller
    {


        private readonly ApplicationDbContext _db;
        // firebase config to upload videos data 
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "Wcx6dndFJJQglNCOOF6IYF0bCMGzjQqQvVfDyAnz",
            BasePath = "https://nourgram-75d1a-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;


        public NourAdmin(ApplicationDbContext db)
        {

            _db = db;
         
        }
        public IActionResult Index()
        {
            List<Video> allVideosForDb = _db.Videos.Include(u => u.Contributor).ToList();
            foreach (var data in allVideosForDb)
            {
                try
                {   
                    client = new FireSharp.FirebaseClient(config);

                    PushResponse response = client.Push("Videos/", data);
                    data.Id = long.Parse(response.Result.name);
                    SetResponse setResponse = client.Set("Videos/" + data.Id, data);

                    if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ModelState.AddModelError(string.Empty, "Added Succesfully");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Something went wrong!!");
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View();
        }
    }
}



