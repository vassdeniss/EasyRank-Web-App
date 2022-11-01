using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Services.Models;

namespace EasyRank.Services.Contracts
{
    public interface IRankService
    {
        Task<ICollection<RankPageServiceModel>> GetAllRankingsAsync();

        Task<RankPageServiceModel> GetRankPageByGuidAsync(Guid rankGuid);
    }
}
