using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMScenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppsettingsController : Controller
    {
      private  readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public AppsettingsController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public   IActionResult  Index()
        {
            AppSittings settings = _db.AppSittings.FirstOrDefault(u => u.Id == 1);
            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);
     }

        // Edit setttings
        // with param id 
        public IActionResult Edit()
        {

            AppSittings settings = _db.AppSittings.FirstOrDefault(u => u.Id == 1);

            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AppSittings obj ,List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;




                if (files[0] != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/logo");
                    var extention = Path.GetExtension(files[0].FileName);

                    if (obj.Logo != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.Logo.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    };



                    obj.Logo = @"\images\logo\" + FileName + extention;

                }
                //.................
                
                if (files[1] != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/Slider");
                    var extention = Path.GetExtension(files[1].FileName);

                    if (obj.SliderImage1 != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.SliderImage1.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        files[1].CopyTo(fileStreams);
                    };



                    obj.SliderImage1 = @"\images\Slider\" + FileName + extention;

                }
                //.................
                
                if (files[2] != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/Slider");
                    var extention = Path.GetExtension(files[2].FileName);

                    if (obj.SliderImage2 != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.SliderImage2.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        files[2].CopyTo(fileStreams);
                    };



                    obj.SliderImage2 = @"\images\Slider\" + FileName + extention;

                }
                //.................
                
                if (files[3] != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/Slider");
                    var extention = Path.GetExtension(files[3].FileName);

                    if (obj.SliderImage3 != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.SliderImage3.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        files[3].CopyTo(fileStreams);
                    };



                    obj.SliderImage3 = @"\images\Slider\" + FileName + extention;

                }
                //.................

                _db.AppSittings.Update(obj);
                _db.SaveChanges();
                //TempData["success"] = "Category has been Edited successfully";
                    
                return RedirectToAction("Index");
            }
            return View(obj);


        }
    }
}
