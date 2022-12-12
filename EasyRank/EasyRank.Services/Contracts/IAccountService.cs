using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace EasyRank.Services.Contracts
{
    // TODO: order namespaces
    // TODO: document

    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(
            string email,
            string? firstName,
            string? lastName,
            string userName,
            string password);
    }
}
