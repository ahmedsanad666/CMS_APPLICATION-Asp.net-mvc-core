
using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using static CMScenter.Views.Models.Common;

namespace CMScenter.Areas.NourAdmin.Controllers
{

    [Area("NourAdmin")]
    public class ContributorController : Controller
    {

        private readonly ApplicationDbContext _db;
        private IWebHostEnvironment _hostEnvironment;

        public ContributorController(ApplicationDbContext db, IWebHostEnvironment hostEnvironment)
        {

            _db = db;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<Contributor> allContributor = _db.Contributors.ToList();
            return View(allContributor);
        }

        //edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contributorItem = _db.Contributors.FirstOrDefault(ui => ui.Id == id);
            if (contributorItem == null)
            {
                return NotFound();
            }

            return View(contributorItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contributor obj, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/contributors");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.ProfileImage != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.ProfileImage.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    };



                    obj.ProfileImage = @"\images\contributors\" + FileName + extention;

                }
                _db.Contributors.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        // create new category

        public IActionResult Create()
        {
            Contributor contributor = new Contributor();
            return View(contributor);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contributor obj, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/contributors");
                    var extention = Path.GetExtension(file.FileName);

                    if (obj.ProfileImage != null)
                    {
                        var oldPath = Path.Combine(wwwRootPath, obj.ProfileImage.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(upload, FileName + extention), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    };



                    obj.ProfileImage = @"\images\contributors\" + FileName + extention;

                }
                _db.Contributors.Add(obj);
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
            var contribuitorItem = _db.Contributors.FirstOrDefault(ui => ui.Id == id);
            return View(contribuitorItem);
        }

        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public IActionResult deleteContributor(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var obj = _db.Contributors.FirstOrDefault(ui => ui.Id == id);

            _db.Contributors.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }



        public IActionResult PinnedContributor()
        {

            List<Contributor> all = _db.Contributors.Where(u => u.ContributorStatus == ContributorStatus.UnderReview).ToList();
            return View(all);
        }

        public async Task<IActionResult> Approve(int id)
        {
            // Retrieve the entity to update from the database
            var item = await _db.Contributors.FirstOrDefaultAsync(u => u.Id == id);

            // Perform updates to the entity as needed
            item.ContributorStatus = ContributorStatus.Approved;

            // Save the changes to the database
            await _db.SaveChangesAsync();

            // Redirect the user to a specific view
            return RedirectToAction("PinnedContributor", "Contributor");
        }

    }
}
