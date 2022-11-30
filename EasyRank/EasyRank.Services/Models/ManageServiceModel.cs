// -----------------------------------------------------------------------
// <copyright file="ManageServiceModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace EasyRank.Services.Models
{
    /// <summary>
    /// The service model for the main account management view.
    /// </summary>
    public class ManageServiceModel
    {
        /// <summary>
        /// Gets or sets the users username.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets the users first name.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the users last name.
        /// </summary>
        public string? LastName { get; set; }

        //public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the users profile picture.
        /// </summary>
        public byte[]? ProfilePicture { get; set; }
    }
}
