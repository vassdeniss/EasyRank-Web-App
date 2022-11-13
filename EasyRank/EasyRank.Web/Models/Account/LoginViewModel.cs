// -----------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace EasyRank.Web.Models.Account
{
    /// <summary>
    /// The view model for when the user is logging in.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets email of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets password of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Gets or sets the return url of the login.
        /// </summary>
        public string? ReturnUrl { get; set; }
    }
}
