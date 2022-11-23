using System;
using System.ComponentModel.DataAnnotations;

using EasyRank.Infrastructure.Models.Accounts;

namespace EasyRank.Infrastructure.Models
{
    public class EasyRankUserRankPage
    {
        [Required]
        public Guid EasyRankUserId { get; set; }

        public EasyRankUser EasyRankUser { get; set; } = null!;

        [Required]
        public Guid RankPageId { get; set; }

        public RankPage RankPage { get; set; } = null!;

        [Required]
        public bool IsLiked { get; set; } = false;
    }
}
