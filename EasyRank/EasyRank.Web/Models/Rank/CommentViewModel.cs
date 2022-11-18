﻿namespace EasyRank.Web.Models.Rank
{
    /// <summary>
    /// The UI side model for the user comment.
    /// </summary>
    public class CommentViewModel
    {
        /// <summary>
        /// Gets or sets the profile picture of the user.
        /// </summary>
        public byte[]? ProfilePicture { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets the time and date the comment has been posted.
        /// </summary>
        public string PostedOn { get; set; } = null!;

        /// <summary>
        /// Gets or sets the comment content.
        /// </summary>
        public string Content { get; set; } = null!;
    }
}
