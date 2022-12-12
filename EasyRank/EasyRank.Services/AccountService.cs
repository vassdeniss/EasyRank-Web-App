using System;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;

using Microsoft.AspNetCore.Identity;

namespace EasyRank.Services
{
    // TODO: document

    public class AccountService : IAccountService
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;


        public AccountService(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(
            string email,
            string? firstName,
            string? lastName,
            string userName,
            string password)
        {
            EasyRankUser user = new EasyRankUser
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
            };

            IdentityResult result = await this.userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }
    }
}

