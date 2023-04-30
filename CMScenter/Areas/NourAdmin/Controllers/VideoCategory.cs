using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace CMScenter.Areas.NourAdmin.Controllers
{

    [Area("NourAdmin")]
    public class VideoCategory : Controller
    {

        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _hostEnvironment;

        public VideoCategory(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {

            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<VideoCat> allCategories = _db.VideoCats.ToList();
            return View(allCategories); 
        }

        //edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catetoryItem = _db.VideoCats.FirstOrDefault(ui => ui.Id == id);
            if (catetoryItem == null)
            {
                return NotFound();
            }

            return View(catetoryItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VideoCat obj ,IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/videoCategoryIcon");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.Icon != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.Icon.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    };



                    obj.Icon = @"\images\videoCategoryIcon\" + FileName + extention;

                }
                _db.VideoCats.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        // create new category

        public IActionResult Create()
        {
            VideoCat videoCat = new VideoCat();
            return View(videoCat);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VideoCat obj , IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/videoCategoryIcon");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.Icon != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.Icon.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    };



                    obj.Icon = @"\images\videoCategoryIcon\" + FileName + extention;

                }
                _db.VideoCats.Add(obj);
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
            var categoryItem = _db.VideoCats.FirstOrDefault(ui => ui.Id == id);
            return View(categoryItem);
        }

        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public IActionResult deleteCategory(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.VideoCats.FirstOrDefault(ui => ui.Id == id);

            _db.VideoCats.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }



    }
}
