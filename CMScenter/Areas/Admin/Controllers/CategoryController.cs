using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMScenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;
        public CategoryController( ApplicationDbContext db)
        {
            _db = db;
        }
      
        public IActionResult Index()
        {
            List<CourseCategory> allCategories = _db.CourseCategories.ToList();
                
            return View(allCategories);
        }

        //edit
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var catetoryItem = _db.CourseCategories.FirstOrDefault(ui => ui.Id == id);
            if(catetoryItem == null)
            {
                return NotFound();
            }

            return View(catetoryItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseCategory obj)
        {

            if (ModelState.IsValid)
            {
                _db.CourseCategories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        // create new category

        public IActionResult Create()
        {
            CourseCategory courseCategory = new CourseCategory();
            return View(courseCategory);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseCategory obj)
        {
            if (ModelState.IsValid)
            {
                _db.CourseCategories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //delete 
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var categoryItem = _db.CourseCategories.FirstOrDefault(ui => ui.Id == id);
            return View(categoryItem);
        }

        [HttpPost,ActionName("delete")]
        [ValidateAntiForgeryToken]
        public IActionResult deleteCategory(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }
            var obj = _db.CourseCategories.FirstOrDefault(ui => ui.Id == id);

            _db.CourseCategories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // return numbers of courses for each category

        public int servicesNumber(int id)
        {
            List<Services> services = _db.Services.ToList();

            int num = services.Count;
            return num;
        }
       
    }
}
