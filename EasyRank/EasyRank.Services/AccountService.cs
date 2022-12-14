using System;
using System.Threading.Tasks;

using EasyRank.Infrastructure.Common;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasyRank.Services
{
    // TODO: header
    // TODO: document

    public class AccountService : IAccountService
    {
        private readonly UserManager<EasyRankUser> userManager;
        private readonly SignInManager<EasyRankUser> signInManager;
        private readonly IRepository repo;

        public AccountService(
            UserManager<EasyRankUser> userManager,
            SignInManager<EasyRankUser> signInManager,
            IRepository repo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.repo = repo;
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

        public async Task<bool> IsEmailConfirmedAsync(string email)
        {
            EasyRankUser? user = await this.repo.AllReadonly<EasyRankUser>(
                    u => u.Email == email)
                .FirstOrDefaultAsync();
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            return user.EmailConfirmed;
        }

        /// <inheritdoc />
        public async Task<SignInResult> SignInUserAsync(string email, string password)
        {
            EasyRankUser? user = await this.repo.AllReadonly<EasyRankUser>(
                    u => u.Email == email)
                .FirstOrDefaultAsync();
            if (user == null || user.IsForgotten)
            {
                throw new NotFoundException();
            }

            return await this.signInManager.PasswordSignInAsync(
                user,
                password,
                false,
                false);
        }
    }
}
