// TODO: header

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;

using Microsoft.AspNetCore.Identity;

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
            this.accountService = new AccountService(
                this.userManager,
                this.signInManager.Object,
                this.repo);
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

        [Test]
        public void Test_IsEmailConfirmed_InvalidEmail_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid email
            Assert.That(
                async() => await this.accountService.IsEmailConfirmedAsync(string.Empty),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsEmailConfirmed_ForgottenEmail_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user email from test db
            string forgottenEmail = this.testDb.ForgottenUser.Email;

            // Act:

            // Assert: NotFoundException is thrown with forgotten email
            Assert.That(
                async() => await this.accountService.IsEmailConfirmedAsync(forgottenEmail),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsEmailConfirmed_NotConfirmed_ReturnsFalse()
        {
            // Arrange: get unconfirmed user email from test db
            string unconfirmedEmail = this.testDb.UnconfirmedUser.Email;

            // Act:

            // Assert: False is returned with unconfirmed email
            Assert.That(
                async() => await this.accountService.IsEmailConfirmedAsync(unconfirmedEmail),
                Is.False);
        }

        [Test]
        public void Test_IsEmailConfirmed_Confirmed_ReturnsTrue()
        {
            // Arrange: get guest user email from test db
            string guestEmail = this.testDb.GuestUser.Email;

            // Act:

            // Assert: False is returned with confirmed email
            Assert.That(
                async () => await this.accountService.IsEmailConfirmedAsync(guestEmail),
                Is.True);
        }

        [Test]
        public void Test_SignInUser_InvalidEmail_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid email
            Assert.That(
                async() => await this.accountService.SignInUserAsync(string.Empty, string.Empty),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_SignInUser_ForgottenEmail_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user email, pass from test db
            string forgottenEmail = this.testDb.ForgottenUser.Email;
            string forgottenPass = "forgotten";

            // Act:

            // Assert: NotFoundException is thrown with forgotten email
            Assert.That(
                async() => await this.accountService.SignInUserAsync(forgottenEmail, forgottenPass),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_SignInUser_ValidUser_DoesNotThrow()
        {
            // Arrange: get guest user email, password from test db
            string guestEmail = this.testDb.GuestUser.Email;
            string guestPass = "guestPass";

            // Act:

            // Assert: No exception is thrown
            Assert.That(
                async() => await this.accountService.SignInUserAsync(guestEmail, guestPass),
                Throws.Nothing);
        }
    }
}
