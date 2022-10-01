using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Controllers
{
    public class RankingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
