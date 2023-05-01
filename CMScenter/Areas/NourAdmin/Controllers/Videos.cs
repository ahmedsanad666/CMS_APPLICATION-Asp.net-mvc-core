

using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
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

        public IActionResult Index()
        {

            List<Video> allvideos;
            if (User.IsInRole("Admin"))
            {   

          allvideos = _db.Videos.Include(u => u.Contributor).ToList();  
            }
            else
            {
            var userId = _userManager.GetUserId(User);

                allvideos = _db.Videos.Where(u => u.ApplicationUserId == userId).Include(u => u.Contributor).ToList();
            }
          

            return View(allvideos);
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
        public IActionResult Edit(Video obj, IFormFile file, string userId)
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
            Video video = new Video();
           


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
        public IActionResult Create(Video obj, IFormFile file,string userId)
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
                _db.Videos.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


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

           List<Video> allvideos = _db.Videos.Where(u => u.VideoStatus == VideoStatus.UnderReview).Include(u => u.Contributor).ToList();
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
