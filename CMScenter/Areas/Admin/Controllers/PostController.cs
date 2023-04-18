using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CMScenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _hostEnvironment;
        public PostController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;


        }
        public IActionResult Index()
        {
            List<Posts> allPosts = _db.posts.Include(u => u.postsCategory).ToList();
            return View(allPosts);
        }

        // create new posst

        public IActionResult Create()
        {
            Posts post = new Posts();

            IEnumerable<SelectListItem> PostCategoryList  = _db.postsCategories.Select(
            u => new SelectListItem
            {
                Text = u.enName,
                Value = u.Id.ToString()
            }
        );

            ViewBag.PostCategoryList = PostCategoryList;
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Posts obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/posts");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.PostImage != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.PostImage.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    };



                    obj.PostImage = @"\images\posts\" + FileName + extention;

                }
                _db.posts.Add(obj);
                _db.SaveChanges();
                //return RedirectToAction("Index", "Post", new { area = "Admin" });
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Edit

        public IActionResult Edit(int id)
        {

            Posts post = _db.posts.FirstOrDefault(u => u.Id == id);
            IEnumerable<SelectListItem> PostCategoryList = _db.postsCategories.Select(
           u => new SelectListItem
           {
               Text = u.enName,
               Value = u.Id.ToString()
           });
            ViewBag.PostCategoryList = PostCategoryList;
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Posts obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/posts");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.PostImage != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.PostImage.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    };



                    obj.PostImage = @"\images\posts\" + FileName + extention;

                }
                _db.posts.Update(obj);
                _db.SaveChanges();
                //return RedirectToAction("Index", "Post", new { area = "Admin" });
                return RedirectToAction("Index");
            }


            return View(obj);
        }


        //delete
        public IActionResult Delete(int id)
        {

            Posts post = _db.posts.FirstOrDefault(u => u.Id == id);
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {

            Posts post = _db.posts.FirstOrDefault(u => u.Id == id);
            if(post == null)
            {
                return NotFound();
            }

            _db.posts.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
