using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyRank.Web.Areas.Identity.Pages.Account.Manage
{
    public class RankingModel : PageModel
    {
        public IActionResult OnGet()
        {
            return this.Page();
        }
    }
}
