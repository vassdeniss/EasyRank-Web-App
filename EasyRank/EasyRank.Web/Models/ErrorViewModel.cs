// -----------------------------------------------------------------------
// <copyright file="ErrorViewModel.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace EasyRank.Web.Models
{
    /// <summary>
    /// The model for displaying error messages.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the exception message of the error.
        /// </summary>
        public string ExceptionMessage { get; set; } = null!;

        /// <summary>
        /// Gets or sets the HTTP status code of the error.
        /// </summary>
        public int StatusCode { get; set; }
    }
}
