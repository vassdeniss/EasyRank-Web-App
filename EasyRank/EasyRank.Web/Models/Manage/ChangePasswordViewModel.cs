// -----------------------------------------------------------------------
// <copyright file="ChangePasswordViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using static EasyRank.Web.Models.ViewModelConstraints.ChangePasswordConstraints;
using static EasyRank.Web.Models.ViewModelConstraints.CommonConstraints;

namespace EasyRank.Web.Models.Manage
{
    /// <summary>
    /// The view model for when the user is changing their password.
    /// </summary>
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// Gets or sets the current password of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; } = null!;

        /// <summary>
        /// Gets or sets the new password set by the user.
        /// </summary>
        [Required]
        [StringLength(MaxPasswordLength, MinimumLength = MinPasswordLength, ErrorMessage = PasswordErrorMessage)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; } = null!;

        /// <summary>
        /// Gets or sets the property that must hold the same value as the new password.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare(nameof(NewPassword), ErrorMessage = ConfirmPasswordErrorMessage)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
