// -----------------------------------------------------------------------
// <copyright file="FileFormatException.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace EasyRank.Services.Exceptions
{
    /// <summary>
    /// The exception thrown when a file's extension is not supported.
    /// </summary>
    public class FileFormatException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileFormatException"/> class.
        /// </summary>
        public FileFormatException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileFormatException"/> class.
        /// </summary>
        /// <param name="message">Message for the exception.</param>
        public FileFormatException(string message)
            : base(message)
        {

        }
    }
}
