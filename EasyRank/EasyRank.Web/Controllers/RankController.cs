using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using EasyRank.Services.Contracts;
using EasyRank.Services.Models;
using EasyRank.Web.Models;

using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Controllers
{
    public class RankController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IRankService rankService;

        public RankController(IMapper mapper, IRankService rankService)
        {
            this.mapper = mapper;
            this.rankService = rankService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            ICollection<RankPageBasicServiceModel> serviceModel = await this.rankService.GetAllRankings();

            ICollection<RankPageBasicViewModel> model =
                this.mapper.Map<ICollection<RankPageBasicViewModel>>(serviceModel);

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ViewRanking(Guid rankId)
        {
            RankPageServiceModel serviceModel = await this.rankService.GetRankPageByGuid(rankId);

            RankPageViewModel model = this.mapper.Map<RankPageViewModel>(serviceModel);

            return this.View(model);
        }
    }
}
