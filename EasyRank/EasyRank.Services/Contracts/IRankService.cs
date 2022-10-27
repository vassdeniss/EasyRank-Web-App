using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EasyRank.Services.Models;

namespace EasyRank.Services.Contracts
{
    public interface IRankService
    {
        Task<ICollection<RankPageBasicServiceModel>> GetAllRankings();

        Task<RankPageServiceModel> GetRankPageByGuid(Guid rankGuid);
    }
}
