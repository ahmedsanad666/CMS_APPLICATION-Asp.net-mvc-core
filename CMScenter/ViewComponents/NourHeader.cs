
using Microsoft.AspNetCore.Mvc;

namespace CMScenter.ViewComponents
{
    public class NourHeader : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
