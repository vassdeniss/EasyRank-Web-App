// -----------------------------------------------------------------------
// <copyright file="ManageViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using static EasyRank.Web.Models.ViewModelConstraints.CommonConstraints;

namespace EasyRank.Web.Models.Manage
{
    /// <summary>
    /// The view model for the main account management view.
    /// </summary>
    public class ManageViewModel
    {
        /// <summary>
        /// Gets or sets the users username.
        /// </summary>
        [Required]
        [StringLength(MaxUsernameLength, MinimumLength = MinUsernameLength)]
        [Display(Name = "Username")]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets the users first name.
        /// </summary>
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the users last name.
        /// </summary>
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        //[Phone]
        //[Display(Name = "Phone number")]
        //public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the users profile picture.
        /// </summary>
        [Display(Name = "Profile Picture")]
        public byte[]? ProfilePicture { get; set; }
    }
}
