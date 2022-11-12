using System.ComponentModel.DataAnnotations;

namespace EasyRank.Web.Models.Manage
{
    /// <summary>
    /// The view model for when the user is changing their email.
    /// </summary>
    public class EmailViewModel
    {
        /// <summary>
        /// Gets or sets the users current email.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Current Email")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets the new email the user has inputted.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "New email")]
        public string NewEmail { get; set; } = null!;
    }
}
