using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMScenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostCategoryController : Controller
    {

        private readonly ApplicationDbContext _db;
        public PostCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            List<PostsCategory> categoris = _db.PostsCategories.ToList();
            return View(categoris);
        }

        // create new posst

        public IActionResult Create()
        {

            PostsCategory postCategory = new PostsCategory();
            return View(postCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostsCategory obj)
        {

            if (ModelState.IsValid)
            {
                _db.PostsCategories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
        //Edit

        public IActionResult Edit(int id)
        {

            PostsCategory postcat = _db.PostsCategories.FirstOrDefault(u => u.Id == id);
            if (postcat == null)
            {
                return NotFound();
            }
            
            return View(postcat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostsCategory obj)
        {

            if (ModelState.IsValid)
            {
                _db.PostsCategories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        //delete
        public IActionResult Delete(int id)
        {
            PostsCategory cat = _db.PostsCategories.FirstOrDefault(u => u.Id == id);

            if (cat == null)
            {
                return NotFound();
            }


            return View(cat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {

            PostsCategory cat = _db.PostsCategories.FirstOrDefault(u => u.Id == id);
            _db.Remove(cat);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
