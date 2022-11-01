﻿using System;
using System.Collections.Generic;

namespace EasyRank.Web.Models
{
    public class RankPageViewModel
    {
        public Guid Id { get; set; }

        public string? Image { get; set; }

        public string ImageAlt { get; set; } = null!;

        public string RankingTitle { get; set; } = null!;

        public string CreatedOn { get; set; } = null!;

        //public ICollection<EasyRankUser> LikedBy { get; set; } = null!;

        public int LikeCount { get; set; }

        public string CreatedByUserName { get; set; } = null!;

        public int CommentCount { get; set; }

        //public ICollection<Comment> Comments { get; set; } = null!;

        public ICollection<RankEntryViewModel> Entries { get; set; } = null!;
    }
}
