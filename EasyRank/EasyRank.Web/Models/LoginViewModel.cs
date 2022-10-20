using System.ComponentModel.DataAnnotations;

namespace EasyRank.Web.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets email of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets password of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        /// <summary>
        /// Gets or sets the return url of the login.
        /// </summary>
        [UIHint("hidden")]
        public string? ReturnUrl { get; set; }
    }
}
