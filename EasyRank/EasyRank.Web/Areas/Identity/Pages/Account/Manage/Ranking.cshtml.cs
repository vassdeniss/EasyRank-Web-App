using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyRank.Web.Areas.Identity.Pages.Account.Manage
{
    public class RankingModel : PageModel
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly IRankService rankService;

        public RankingModel(
            UserManager<EasyRankUser> userManager,
            IRankService rankService)
        {
            this.userManager = userManager;
            this.rankService = rankService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGet()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);

            ICollection<RankPageServiceModel> b = await this.rankService.GetAllRankingsByUserAsync(user.Id);

            this.Input = new InputModel
            {
                TItles = b.Select(x => x.RankingTitle).ToList(),
            };

            return this.Page();
        }

        public class InputModel
        {
            public ICollection<string> TItles { get; set; }
        }
    }
}
