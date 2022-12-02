// -----------------------------------------------------------------------
// <copyright file="VerifyEmailViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace EasyRank.Web.Models.Account
{
    /// <summary>
    /// The view model for when the user is verifying their email.
    /// </summary>
    public class VerifyEmailViewModel
    {
        /// <summary>
        /// Gets or sets the users current email.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
