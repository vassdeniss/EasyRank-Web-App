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
        }
    }
}
