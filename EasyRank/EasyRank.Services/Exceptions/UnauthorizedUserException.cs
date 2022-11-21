// -----------------------------------------------------------------------
// <copyright file="UnauthorizedUserException.cs" company="Denis Vasilev">
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
    public class UnauthorizedUserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedUserException"/> class.
        /// </summary>
        public UnauthorizedUserException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedUserException"/> class.
        /// </summary>
        /// <param name="message">Message for the exception.</param>
        public UnauthorizedUserException(string message)
            : base(message)
        {

        }
    }
}
