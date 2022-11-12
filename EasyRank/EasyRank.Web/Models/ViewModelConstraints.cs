namespace EasyRank.Web.Models
{
    /// <summary>
    /// Class for holding all view model constraints.
    /// </summary>
    public class ViewModelConstraints
    {
        /// <summary>
        /// Class for holding 'Manage' view model constraints.
        /// </summary>
        public class ManageConstraints
        {
            /// <summary>
            /// The upper bound constant number for the length of the username.
            /// </summary>
            public const int MaxUsernameLength = 20;

            /// <summary>
            /// The lower bound constant number for the length of the username.
            /// </summary>
            public const int MinUsernameLength = 3;
        }
    }
}
