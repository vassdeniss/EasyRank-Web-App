using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Models;
using EasyRank.Services.Contracts;
using EasyRank.Services.Models;

using Microsoft.EntityFrameworkCore;

namespace EasyRank.Services
{
    public class RankService : IRankService
    {
        private readonly IRepository repo;

        public RankService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<ICollection<RankPageBasicServiceModel>> GetAllRankings()
        {
            return await this.repo.AllReadonly<RankPage>()
                .Include(rp => rp.CreatedByUser)
                .Select(p => new RankPageBasicServiceModel
                {
                    Id = p.Id,
                    RankingTitle = p.RankingTitle,
                    CreatedOn = p.CreatedOn.ToString("dd MMMM yyyy"),
                    LikeCount = p.LikedBy.Count,
                    CreatedByUserName = p.CreatedByUser.UserName,
                    CommentCount = p.Comments.Count
                })
                .ToListAsync();
        }

        public async Task<RankPageServiceModel> GetRankPageByGuid(Guid rankGuid)
        {
            RankPage rankPage = await this.repo.AllReadonly<RankPage>(rp => rp.Id == rankGuid)
                .Include(rp => rp.Entries)
                .Include(rp => rp.CreatedByUser)
                .FirstAsync();

            RankPageServiceModel rankPageServiceModel
                = new RankPageServiceModel
                {
                    RankingTitle = rankPage.RankingTitle,
                    CreatedOn = rankPage.CreatedOn.ToString("dd MMMM yyyy"),
                    LikeCount = rankPage.LikedBy.Count,
                    CreatedByUserName = rankPage.CreatedByUser.UserName,
                    CommentCount = rankPage.Comments.Count,
                    Entries = rankPage.Entries.Select(re => new RankEntryServiceModel
                    {
                        Placement = re.Placement,
                        Title = re.Title,
                        Image = re.Image,
                        Description = re.Description
                    })
                    .ToList()
                };

            return rankPageServiceModel;
        }
    }
}
