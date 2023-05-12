

using Azure.Core;
using CMScenter.Data;
using CMScenter.Views.Models;
using FireSharp.Config;
using FireSharp.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using VimeoDotNet;
using VimeoDotNet.Models;
using VimeoDotNet.Net;
using static CMScenter.Views.Models.Common;


namespace CMScenter.Areas.NourAdmin.Controllers
{

    [Area("NourAdmin")]
    public class Videos : Controller
    {

        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _hostEnvironment;   
        private readonly UserManager<IdentityUser> _userManager;
    


        public Videos(ApplicationDbContext db, IWebHostEnvironment hostEnvironment , UserManager<IdentityUser> userManager )
        {
            _userManager = userManager;
            _db = db;
            _hostEnvironment = hostEnvironment;
      
        }

 

        public async Task<IActionResult> Index()
        {

            string AccessToken = "60d02ef45091f2d7ecda6c7d1514532a";

            try {

                VimeoClient vimeoClient = new VimeoClient(AccessToken);
                var authCheck = await vimeoClient.GetAccountInformationAsync();
           
            }catch(Exception e) {

         Console.WriteLine($"messsage:{e}");
            }

            // vemeo auth.................
            List<Views.Models.Video> allvideos;
   
            if (User.IsInRole("Admin"))
            {   

          allvideos = _db.Videos.Include(u => u.Contributor).ToList();  
            }
            else
            {
            var userId = _userManager.GetUserId(User);

                allvideos = _db.Videos.Where(u => u.ApplicationUserId == userId).Include(u => u.Contributor).ToList();
            }
         
            //...................


         
            return View(allvideos);
        }

        public JsonResult GetUserData()
        {
            // Retrieve user data from the database using the provided id
            var allvideos = _db.Videos.Include(u => u.Contributor).ToList();
            //var serializerOptions = new JsonSerializerOptions
            //{
            //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //    WriteIndented = true,
             
            //};
            //var jsonResult = new JsonResult(allvideos, serializerOptions);
            // Return the user data as JSON
            return Json(allvideos );
        }

        //edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoItem = _db.Videos.FirstOrDefault(ui => ui.Id == id);
            if (videoItem == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> Contributor = _db.Contributors.Select(
                u => new SelectListItem
                {
                    Text = u.EnName,
                    Value = u.Id.ToString()
                });

            IEnumerable<SelectListItem> VideoCat = _db.VideoCats.Select(
                u => new SelectListItem
                {
                    Text = u.EnName,
                    Value = u.Id.ToString()
                });


            ViewBag.contributors = Contributor;
            ViewBag.VideoCat = VideoCat;

       

            return View(videoItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Views.Models.Video obj, IFormFile file, string userId)
        {
            obj.ApplicationUserId = userId;
                
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/VideosImages");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.Thumbnail != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.Thumbnail.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    };



                    obj.Thumbnail = @"\images\VideosImages\" + FileName + extention;

                }
                _db.Videos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        // create new category

        public IActionResult Create()
        {
            Views.Models.Video video = new Views.Models.Video();
           


            IEnumerable<SelectListItem> Contributor = _db.Contributors.Select(
                u => new SelectListItem
                {
                    Text = u.EnName,
                    Value = u.Id.ToString()
                });

            IEnumerable<SelectListItem> VideoCat = _db.VideoCats.Select(
                u => new SelectListItem
                {
                    Text = u.EnName,
                    Value = u.Id.ToString()
                });
           

            ViewBag.contributors = Contributor; 
            ViewBag.VideoCat = VideoCat; 

            return View(video);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Views.Models.Video obj, IFormFile file,string userId,IFormFile VideoFile)
        {


                    string uploadStatus = "";
              obj.ApplicationUserId = userId;
            string AccessToken = "60d02ef45091f2d7ecda6c7d1514532a";
            try {

                if (ModelState.IsValid)
                {
            
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    if (file != null)
                    {
                        string FileName = Guid.NewGuid().ToString();
                        // find the final location
                        var upload = Path.Combine(wwwRootPath, @"images/VideosImages");
                        var extention = Path.GetExtension(file.FileName);

                        if (obj.Thumbnail != null)
                        {
                            var oldPath = Path.Combine(wwwRootPath, obj.Thumbnail.TrimStart('\\'));
                            if (System.IO.File.Exists(oldPath))
                            {
                                System.IO.File.Delete(oldPath);
                            }
                        }
                        using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                        {
                            file.CopyTo(fileStreams);
                        };



                        obj.Thumbnail = @"\images\VideosImages\" + FileName + extention;

                    }
                    //..................upload to vimeo
                    if(VideoFile != null)
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    VimeoClient vimeoClient = new VimeoClient(AccessToken);
                    var authCheck = await vimeoClient.GetAccountInformationAsync();
                        if(authCheck.Name != null)
                        {
                            UploadRequest uploadRequest = new UploadRequest() ;
                     
                            BinaryContent binaryContent = new BinaryContent(VideoFile.OpenReadStream(), VideoFile.ContentType);

                          
                            int chunkSize = 0;
                            int contentLength = VideoFile.ContentType.Length;   
                            int temp1 = contentLength / 1024;
                            if(temp1 > 1) {
                            chunkSize = temp1 / 1024;
                                chunkSize = chunkSize / 10;
                                chunkSize = chunkSize * 1048576;
                            }
                            else
                            {
                                chunkSize = 1048576; 

                            }
                            //uploadRequest.Ticket.Name = obj.EnTitle;
                           
                            uploadRequest = (UploadRequest)await vimeoClient.UploadEntireFileAsync(binaryContent, chunkSize, null);
                        
                            uploadStatus = string.Concat("file uploaded", "https://vimeo.com/", uploadRequest.ClipId.Value.ToString(), "/none");
                            obj.Link = uploadRequest.ClipUri;
                            
                            Console.WriteLine("sdf");
                        }
                    }
                    //............................
                    _db.Videos.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }



            }
            catch (Exception ex)
            {
                 uploadStatus = ("failed" + ex.Message);
            }

            ViewBag.uploadStatus = uploadStatus;
            return View(obj);
        }

        //delete 
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var video = _db.Videos.FirstOrDefault(ui => ui.Id == id);
            return View(video);
        }

        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public IActionResult deleteCategory(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Videos.FirstOrDefault(ui => ui.Id == id);

            _db.Videos.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult PinnedVideos()
        {

           List<Views.Models.Video> allvideos = _db.Videos.Where(u => u.VideoStatus == VideoStatus.UnderReview).Include(u => u.Contributor).ToList();
            return View(allvideos);
        }



        public async Task<IActionResult> Approve(int id)
        {
            // Retrieve the entity to update from the database
            var item = await _db.Videos.FirstOrDefaultAsync(u => u.Id == id);

            // Perform updates to the entity as needed
            item.VideoStatus = VideoStatus.Approved;

            // Save the changes to the database
            await _db.SaveChangesAsync();

            // Redirect the user to a specific view
            return RedirectToAction("PinnedVideos", "Videos");
        }



    }
}
