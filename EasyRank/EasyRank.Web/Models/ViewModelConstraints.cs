// -----------------------------------------------------------------------
// <copyright file="ViewModelConstraints.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace EasyRank.Web.Models
{
    /// <summary>
    /// Class for holding all view model constraints.
    /// </summary>
    public class ViewModelConstraints
    {
        /// <summary>
        /// Class for holding 'Register' view model constraints.
        /// </summary>
        public class RegisterConstraints
        {
            /// <summary>
            /// The upper bound constant number for the length of the first name.
            /// </summary>
            public const int MaxFirstNameLength = 8;

            /// <summary>
            /// The upper bound constant number for the length of the last name.
            /// </summary>
            public const int MaxLastNameLength = 10;
        }

        /// <summary>
        /// Class for holding 'ChangePassword' view model constraints.
        /// </summary>
        public class ChangePasswordConstraints
        {
            /// <summary>
            /// The upper bound constant number for the length of the password.
            /// </summary>
            public const int MaxPasswordLength = 100;

            /// <summary>
            /// The lower bound constant number for the length of the password.
            /// </summary>
            public const int MinPasswordLength = 7;

            /// <summary>
            /// The error message when the password does not satisfy the given length.
            /// </summary>
            public const string PasswordErrorMessage = "The {0} must be at least {2} characters long.";
        }

        /// <summary>
        /// Class for holding 'Comment' view model constraints.
        /// </summary>
        public class CommentConstraints
        {
            /// <summary>
            /// The upper bound constant number for the length of the comment.
            /// </summary>
            public const int MaxCommentLength = 1000;

            /// <summary>
            /// The lower bound constant number for the length of the comment.
            /// </summary>
            public const int MinCommentLength = 30;

            /// <summary>
            /// The error message when the comment is empty.
            /// </summary>
            public const string CommentEmptyErrorMessage = "The comment cannot be empty.";

            /// <summary>
            /// The error message when the comments length does not satisfy the given length.
            /// </summary>
            public const string CommentLengthErrorMessage = 
                "The comments must be at least {2} characters long so they add substantively to the discussion. Click the \"I like!\" button if you just want to say \"Good job!\".";
        }

        /// <summary>
        /// Class for holding the 'RankPage' constraints.
        /// </summary>
        public class RankPageConstraints
        {
            /// <summary>
            /// The upper bound constant number for the rank title.
            /// </summary>
            public const int MaxRankTitleLength = 50;

            /// <summary>
            /// The upper bound constant number for the rank title.
            /// </summary>
            public const int MinRankTitleLength = 10;

            /// <summary>
            /// The error message when the rank title length does not satisfy the given length.
            /// </summary>
            public const string RankTitleErrorMessage = "The {0} must be at least {2} characters long.";
        }

        /// <summary>
        /// Class for holding the 'RankEntry' constraints.
        /// </summary>
        public class RankEntryConstraints
        {
            /// <summary>
            /// The upper bound constant number for the entry title.
            /// </summary>
            public const int MaxEntryTitleLength = 50;

            /// <summary>
            /// The lower bound constant number for the entry title.
            /// </summary>
            public const int MinEntryTitleLength = 10;

            /// <summary>
            /// The error message when the entry title length does not satisfy the given length.
            /// </summary>
            public const string EntryTitleErrorMessage = "The {0} must be at least {2} characters long.";

            /// <summary>
            /// The upper bound constant number for the entry description.
            /// </summary>
            public const int MaxEntryDescriptionLength = 1000;

            /// <summary>
            /// The lower bound constant number for the entry description.
            /// </summary>
            public const int MinEntryDescriptionLength = 50;

            /// <summary>
            /// The error message when the entry title length does not satisfy the given length.
            /// </summary>
            public const string EntryDescriptionErrorMessage = "The {0} must be at least {2} characters long.";

            /// <summary>
            /// The upper bound constant number for the entry position.
            /// </summary>
            public const int MaxPlacement = 10;

            /// <summary>
            /// The lower bound constant number for the entry position.
            /// </summary>
            public const int MinPlacement = 1;
        }

        /// <summary>
        /// Class for holding common view model constraints.
        /// </summary>
        public class CommonConstraints
        {
            /// <summary>
            /// The upper bound constant number for the length of the username.
            /// </summary>
            public const int MaxUsernameLength = 20;

            /// <summary>
            /// The lower bound constant number for the length of the username.
            /// </summary>
            public const int MinUsernameLength = 3;

            /// <summary>
            /// The error message when the two passwords do not match each other.
            /// </summary>
            public const string ConfirmPasswordErrorMessage =
                "The new password and confirmation password do not match.";

            /// <summary>
            /// The upper bound constant number for the entry's image alt text.
            /// </summary>
            public const int MaxImageAltLength = 50;

            /// <summary>
            /// The lower bound constant number for the entry's image alt text.
            /// </summary>
            public const int MinImageAltLength = 5;

            /// <summary>
            /// The error message when the image alt length does not satisfy the given length.
            /// </summary>
            public const string ImageAltErrorMessage = "The {0} must be at least {2} characters long.";
        }
    }
}
