// -----------------------------------------------------------------------
// <copyright file="EmailServiceModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace EasyRank.Services.Models.Email
{
    /// <summary>
    /// The service model for when the user is changing their email.
    /// </summary>
    public class EmailServiceModel
    {
        /// <summary>
        /// Gets or sets the users current email.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets the new email the user has inputted.
        /// </summary>
        public string NewEmail { get; set; } = null!;
    }
}
