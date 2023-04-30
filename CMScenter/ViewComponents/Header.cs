using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CMScenter.ViewComponents
{

    public class Header : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public Header(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewModel vmModel = new ViewModel()
            {
                appSettings = await _db.AppSittings.FirstOrDefaultAsync(u => u.Id == 1),
                subMenu = await _db.SubmenuBoxes.ToListAsync()
            };
            AppSittings settings = await _db.AppSittings.FirstOrDefaultAsync(u => u.Id == 1);




            return View(vmModel);
        }
    }
}
