// -----------------------------------------------------------------------
// <copyright file="ForbiddenException.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace EasyRank.Services.Exceptions
{
    /// <summary>
    /// The exception thrown when a user does not have access to a given action.
    /// </summary>
    public class ForbiddenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        public ForbiddenException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">Message for the exception.</param>
        public ForbiddenException(string message)
            : base(message)
        {

        }
    }
}
