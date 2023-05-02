using CMScenter.Areas.Admin.Controllers;
using CMScenter.Data;
using CMScenter.Views.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Configuration;

namespace CMScenter.ViewComponents
{

    public class Footer : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public Footer(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppSittings settings = await _db.AppSittings.FirstOrDefaultAsync();

            ViewModel vmModel = new ViewModel()
            {
                appSettings = settings == null ? new AppSittings() : settings,
            };
            //AppSittings settings = await _db.AppSittings.FirstOrDefaultAsync(u => u.Id == 1);


           

            return View(vmModel);
        }
    }
}
