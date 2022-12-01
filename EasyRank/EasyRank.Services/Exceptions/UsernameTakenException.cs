// -----------------------------------------------------------------------
// <copyright file="UsernameTakenException.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace EasyRank.Services.Exceptions
{
    /// <summary>
    /// The exception thrown when a user tries to enter a taken username.
    /// </summary>
    public class UsernameTakenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameTakenException"/> class.
        /// </summary>
        public UsernameTakenException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameTakenException"/> class.
        /// </summary>
        /// <param name="message">Message for the exception.</param>
        public UsernameTakenException(string message)
            : base(message)
        {

        }
    }
}
