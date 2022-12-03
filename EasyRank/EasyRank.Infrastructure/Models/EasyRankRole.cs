using System;

using Microsoft.AspNetCore.Identity;

namespace EasyRank.Infrastructure.Models
{
    public class EasyRankRole : IdentityRole<Guid>
    {
        public EasyRankRole() : base() { }

        public EasyRankRole(string roleName)
            : base(roleName) { }
    }
}
