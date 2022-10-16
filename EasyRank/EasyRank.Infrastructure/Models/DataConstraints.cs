// -----------------------------------------------------------------------
// <copyright file="DataConstraints.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace EasyRank.Infrastructure.Models
{
    /// <summary>
    /// Class for holding all data constraints.
    /// </summary>
    public class DataConstraints
    {
        /// <summary>
        /// Class for holding the 'EasyRankUser' constraints.
        /// </summary>
        public class EasyRankUserConstraints
        {

        }

        /// <summary>
        /// Class for holding the 'Comment' constraints.
        /// </summary>
        public class Comment
        {
            /// <summary>
            /// The upper bound constant number for the length of the comment.
            /// </summary>
            public const int MaxCommentLength = 500;
        }

        /// <summary>
        /// Class for holding the 'RankPage' constraints.
        /// </summary>
        public class RankPage
        {
            /// <summary>
            /// The upper bound constant number for the rank title.
            /// </summary>
            public const int MaxRankTitle = 30;
        }

        /// <summary>
        /// Class for holding the 'RankEntry' constraints.
        /// </summary>
        public class RankEntryConstraints
        {
            /// <summary>
            /// The upper bound constant number for the entry title.
            /// </summary>
            public const int MaxEntryTitle = 30;

            /// <summary>
            /// The upper bound constant number for the entry description.
            /// </summary>
            public const int MaxEntryDescription = 1000;

            /// <summary>
            /// The upper bound constant number for the entry image length.
            /// </summary>
            public const int MaxImageLinkLength = 2048;
        }
    }
}
