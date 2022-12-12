// TODO: header

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace EasyRank.Services.UnitTests
{
    [TestFixture]
    public class AccountServiceTests : UnitTestBase
    {
        private UserManager<EasyRankUser> userManager;
        private IAccountService accountService;

        [SetUp]
        public void SetUp()
        {
            this.userManager = base.userManager.Object;
            this.accountService = new AccountService(this.userManager, this.signInManager.Object);
        }

        [Test]
        public async Task Test_CreateUser_AddsSuccessfully()
        {
            // Arrange: get the count of users before adding
            int usersCountBefore = this.userManager.Users
                .ToList()
                .Count;

            // Arrange: create data for a new user to be added
            string email = "fakeEmail@mail.bg";
            string username = "fakeUser";
            string password = "123456";

            // Act: call the service method and pass the necessary data
            await this.accountService.CreateUserAsync(
                email, 
                string.Empty,
                string.Empty,
                username,
                password);

            // Assert: the count of users has increased by one
            int userCountAfter = this.userManager.Users
                .ToList()
                .Count;
            Assert.That(userCountAfter, Is.EqualTo(usersCountBefore + 1));

            // Assert: the new user has been added
            EasyRankUser? newUserInDb = await this.userManager.FindByEmailAsync(email);
            Assert.That(newUserInDb, Is.Not.Null);
            Assert.That(newUserInDb!.Email, Is.EqualTo(email));
            Assert.That(newUserInDb.UserName, Is.EqualTo(username));
            Assert.That(newUserInDb.FirstName, Is.EqualTo(string.Empty));
            Assert.That(newUserInDb.LastName, Is.EqualTo(string.Empty));
            Assert.That(newUserInDb.ProfilePicture, Is.Null);
        }
    }
}
