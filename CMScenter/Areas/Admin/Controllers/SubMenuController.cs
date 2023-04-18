using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMScenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubMenuController : Controller
    {

        private readonly ApplicationDbContext _db;
     
        public SubMenuController(ApplicationDbContext db)
        {
            _db = db;
         


        }
        public IActionResult Index()
        {
            List<SubmenuBox> submenu = _db.submenuBoxes.ToList();
            return View(submenu);
        }

        // edit 
        public IActionResult Edit(int id)
        {
            SubmenuBox submenu = _db.submenuBoxes.FirstOrDefault(u => u.Id == id);

            if (submenu == null)
            {
                return NotFound(); 
            }
        
            return View(submenu);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SubmenuBox obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.submenuBoxes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
