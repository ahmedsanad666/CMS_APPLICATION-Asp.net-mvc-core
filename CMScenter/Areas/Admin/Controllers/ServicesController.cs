using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CMScenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {

        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _hostEnvironment;
        public ServicesController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;

                    
        }

     
        public IActionResult Index(int id)
        {

           

            List<Services> services = _db.Services.Where(u => u.CourseCategoryId == id).Include(u => u.courseCategory).ToList();

            return View(services);
        }

        //create 
        public IActionResult Create()
        {
            Services services = new Services();

            IEnumerable<SelectListItem> CategoryList = _db.CourseCategories.Select(
              u => new SelectListItem
              {
                  Text = u.enName,
                  Value = u.Id.ToString()
              }
          );

            ViewBag.CategoryList = CategoryList;

            return View(services);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Services obj ,IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/services");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.Image != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    };



                    obj.Image = @"\images\services\" + FileName + extention;

                }
                _db.Services.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }



            return View(obj);
        }

        //edit 
        public IActionResult Edit(int id)
        {
       
            Services services = _db.Services.FirstOrDefault(u => u.Id == id);

            IEnumerable<SelectListItem> CategoryList = _db.CourseCategories.Select(
              u => new SelectListItem
              {
                  Text = u.enName,
                  Value = u.Id.ToString()
              }
          );

            ViewBag.CategoryList = CategoryList;

            return View(services);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Services obj, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/services");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.Image != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    };



                    obj.Image = @"\images\services\" + FileName + extention;

                }
                _db.Services.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category", new { area = "Admin" });
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
            var services = _db.Services.FirstOrDefault(ui => ui.Id == id);
            return View(services);
        }

        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public IActionResult deleteServ(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Services.FirstOrDefault(ui => ui.Id == id);

            _db.Services.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index","Category",new {area = "admin"});

        }



    }
}
