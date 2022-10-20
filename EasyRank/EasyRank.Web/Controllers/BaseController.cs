// -----------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyRank.Web.Controllers
{
    /// <summary>
    /// Base controller class which makes all other controllers locked with authorization.
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
    }
}
