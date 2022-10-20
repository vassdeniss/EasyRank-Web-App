// -----------------------------------------------------------------------
// <copyright file="RegisterViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace EasyRank.Web.Models
{
    /// <summary>
    /// The view model for when the user is registering.
    /// </summary>
    public class RegisterViewModel
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
        /// Gets or sets the password repeated for confirmation.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; } = null!;

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Username")]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        /// <remarks>Optional.</remarks>
        [StringLength(8)]
        [Display(Name = "First Name (Optional)")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        /// <remarks>Optional.</remarks>
        [StringLength(10)]
        [Display(Name = "Last Name (Optional)")]
        public string? LastName { get; set; }
    }
}
