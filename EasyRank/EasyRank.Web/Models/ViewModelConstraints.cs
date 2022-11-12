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
        /// Class for holding 'Manage' view model constraints.
        /// </summary>
        public class ManageConstraints
        {
            /// <summary>
            /// The upper bound constant number for the length of the username.
            /// </summary>
            public const int MaxUsernameLength = 20;

            /// <summary>
            /// The lower bound constant number for the length of the username.
            /// </summary>
            public const int MinUsernameLength = 3;
        }

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

            /// <summary>
            /// The error message when the two passwords do not match eachother.
            /// </summary>
            public const string ConfirmPasswordErrorMessage =
                "The new password and confirmation password do not match.";
        }
    }
}
