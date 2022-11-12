// -----------------------------------------------------------------------
// <copyright file="DeleteAccountViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace EasyRank.Web.Models.Manage
{
    /// <summary>
    /// The view model for account deletion.
    /// </summary>
    public class DeleteAccountViewModel
    {
        /// <summary>
        /// Gets or sets the current password of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
