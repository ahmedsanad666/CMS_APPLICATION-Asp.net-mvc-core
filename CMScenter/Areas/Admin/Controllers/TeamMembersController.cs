using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


namespace CMScenter.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMembersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public TeamMembersController(ApplicationDbContext db, IWebHostEnvironment hostenvironment)
        {
            _db = db;
            _hostEnvironment = hostenvironment;
        }



        public IActionResult Index()
        {

            List<TeamMember> TeamMemberObj = _db.TeamMembers.ToList();
            return View(TeamMemberObj);
        }


        //create
        public IActionResult Create()
        {
            TeamMember teamMember = new TeamMember();

            return View(teamMember);

        }

        [HttpPost]  
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeamMember obj , IFormFile file)
        {



            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/TeamMembers");
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



                    obj.Image = @"\images\TeamMembers\" + FileName + extention;

                }

                _db.TeamMembers.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        //edit
        public IActionResult Edit(int? id)
        {
            // get 1 member data by id 
           if(id == null)
            {
                return NotFound();
            }
            var MemberData = _db.TeamMembers.FirstOrDefault(ui => ui.Id == id);
            if(MemberData == null)
            {
                return NotFound();
            }


            return View(MemberData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TeamMember obj , IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString();
                    // find the final location
                    var upload = Path.Combine(wwwRootPath, @"images/TeamMembers");
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



                    obj.Image = @"\images\TeamMembers\" + FileName + extention;

                }

                _db.TeamMembers.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // delete
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var memberItem = _db.TeamMembers.FirstOrDefault(ui => ui.Id == id);
            if(memberItem == null)
            {
                return NotFound();
            }


            return View(memberItem);
        }


        [HttpPost,ActionName("delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMember(int? id)
        {

            var teamItem = _db.TeamMembers.FirstOrDefault(ui => ui.Id == id);

            if(teamItem == null)
            {
                return NotFound();
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, teamItem.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _db.TeamMembers.Remove(teamItem);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
