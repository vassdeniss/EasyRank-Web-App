// -----------------------------------------------------------------------
// <copyright file="NotFoundException.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace EasyRank.Services.Exceptions
{
    /// <summary>
    /// The exception thrown when a model was not found in the database.
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        public NotFoundException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">Message for the exception.</param>
        public NotFoundException(string message)
            : base(message)
        {

        }
    }
}
