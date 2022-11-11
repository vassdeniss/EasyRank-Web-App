// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyRank.Web.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    /// The razor page responsible for changing basic account settings.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="userManager">The manager responsible for users.</param>
        /// <param name="signInManager">The manager responsible for sign ins.</param>
        public IndexModel(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the property that displays a message on success or on error.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the property used as a model for the view.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        /// The get method for the razor page.
        /// </summary>
        /// <returns>A view for changing basic user account settings.</returns>
        public async Task<IActionResult> OnGetAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            await this.LoadAsync(user);
            return this.Page();
        }

        /// <summary>
        /// The post method for the razor page.
        /// </summary>
        /// <returns>The same page for changing user settings with a success / failure message.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            //var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}

            string firstName = user.FirstName;
            if (this.Input.FirstName != firstName)
            {
                user.FirstName = this.Input.FirstName;
            }

            string lastName = user.LastName;
            if (this.Input.LastName != lastName)
            {
                user.LastName = this.Input.LastName;
            }

            if (this.Input.Username == null)
            {
                this.StatusMessage = "Error: Username is empty!";
                return this.RedirectToPage();
            }

            string username = user.UserName;
            if (this.Input.Username != username)
            {
                EasyRankUser userWithGivenUsername = await this.userManager.FindByNameAsync(this.Input.Username);
                if (userWithGivenUsername != null)
                {
                    this.StatusMessage = "Error: Username taken!";
                    return this.RedirectToPage();
                }

                await this.userManager.SetUserNameAsync(user, this.Input.Username);
            }

            if (this.Request.Form.Files.Count > 0)
            {
                IFormFile file = this.Request.Form.Files.FirstOrDefault();

                using MemoryStream memoryStream = new MemoryStream();

                await file!.CopyToAsync(memoryStream);
                user.ProfilePicture = memoryStream.ToArray();
            }

            await this.userManager.UpdateAsync(user);

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";

            return this.RedirectToPage();
        }

        /// <summary>
        /// The post method for the razor page.
        /// </summary>
        /// <returns>The same page for changing user settings with a deleted profile picture.</returns>
        /// <remarks>Post for when profile picture is getting deleted.</remarks>
        public async Task<IActionResult> OnPostDeleteProfilePictureAsync()
        {
            EasyRankUser user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            user.ProfilePicture = null;

            await this.userManager.UpdateAsync(user);

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";

            return this.RedirectToPage();
        }

        private async Task LoadAsync(EasyRankUser user)
        {
            string userName = await this.userManager.GetUserNameAsync(user);
            //string phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            string firstName = user.FirstName;
            string lastName = user.LastName;
            byte[] profilePicture = user.ProfilePicture;

            this.Input = new InputModel
            {
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                ProfilePicture = profilePicture,
            };
        }

        /// <summary>
        /// The view model for the email change.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            /// Gets or sets the users username.
            /// </summary>
            [StringLength(20, MinimumLength = 3)]
            [Display(Name = "Username")]
            public string Username { get; set; }

            /// <summary>
            /// Gets or sets the users first name.
            /// </summary>
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            /// <summary>
            /// Gets or sets the users last name.
            /// </summary>
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            //[Phone]
            //[Display(Name = "Phone number")]
            //public string PhoneNumber { get; set; }

            /// <summary>
            /// Gets or sets the users profile picture.
            /// </summary>
            [Display(Name = "Profile Picture")]
            public byte[] ProfilePicture { get; set; }
        }
    }
}
