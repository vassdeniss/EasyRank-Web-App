// TODO: header

using System.Text;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;

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

        [Test]
        public void Test_GetUserIdByEmail_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid email
            Assert.That(
                async() => await this.accountService.GetUserIdByEmail(string.Empty),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetUserIdByEmail_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with invalid email
            Assert.That(
                async() => await this.accountService.GetUserIdByEmail(forgottenUser.Email),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetUserIdByEmail_ReturnsCorrectId()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Act: call service method and pass in necessary data
            Guid id = await this.accountService.GetUserIdByEmail(denisUser.Email);

            // Assert: both ids are the same
            Assert.That(id, Is.EqualTo(denisUser.Id));
        }

        [Test]
        public async Task Test_DoesUserExist_ReturnsFalse()
        {
            // Arrange:

            // Act: call service method and pass in necessary data
            bool result = await this.accountService.DoesUserExist(string.Empty);

            // Assert: result is false
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task Test_DoesUserExist_ReturnsTrue()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Act: call service method and pass in necessary data
            bool result = await this.accountService.DoesUserExist(denisUser.Email);

            // Assert: result is false
            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_GenerateChangeEmailToken_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.accountService.GenerateChangeEmailTokenAsync(
                    Guid.NewGuid(),
                    "RandomEmail"),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GenerateChangeEmailToken_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async () => await this.accountService.GenerateChangeEmailTokenAsync(forgottenUser.Id, "RandomEmail"),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GenerateChangeEmailToken_GeneratesCorrectly()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: create sample code
            string expectedCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes("random-string"));

            // Act: call service method and pass in necessary data
            string actualCode = await this.accountService.GenerateChangeEmailTokenAsync(denisUser.Id, denisUser.Email);

            // Assert: both codes are the same
            Assert.That(actualCode, Is.EqualTo(expectedCode));
        }

        [Test]
        public void Test_GenerateEmailConfirmationToken_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.accountService.GenerateEmailConfirmationTokenAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GenerateEmailConfirmationToken_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async () => await this.accountService.GenerateEmailConfirmationTokenAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GenerateEmailConfirmationToken_GeneratesCorrectly()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: create sample code
            string expectedCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes("random-string"));

            // Act: call service method and pass in necessary data
            string actualCode = await this.accountService.GenerateEmailConfirmationTokenAsync(denisUser.Id);

            // Assert: both codes are the same
            Assert.That(actualCode, Is.EqualTo(expectedCode));
        }

        [Test]
        public void Test_GeneratePasswordResetToken_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.accountService.GeneratePasswordResetTokenAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GeneratePasswordResetToken_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async () => await this.accountService.GeneratePasswordResetTokenAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GeneratePasswordResetToken_GeneratesCorrectly()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: create sample code
            string expectedCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes("random-string"));

            // Act: call service method and pass in necessary data
            string actualCode = await this.accountService.GeneratePasswordResetTokenAsync(denisUser.Id);

            // Assert: both codes are the same
            Assert.That(actualCode, Is.EqualTo(expectedCode));
        }

        [Test]
        public void Test_ResetPasswordAsync_InvalidUserEmail_ThrowsNotFoundException()
        {
            // Arrange: create invalid email, code, random password
            string email = "randomEmail@mail.com";
            string code = "some-code";
            string password = "some-password123";

            // Act:

            // Assert: NotFoundException is thrown with invalid user
            Assert.That(
                async() => await this.accountService.ResetPasswordAsync(email, code, password),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_ResetPasswordAsync_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user email from test db, create code, create random password
            string forgottenEmail = this.testDb.ForgottenUser.Email;
            string code = "some-code";
            string password = "some-password123";

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async() => await this.accountService.ResetPasswordAsync(forgottenEmail, code, password),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_ResetPasswordAsync_ValidUser_DoesNotThrow()
        {
            // Arrange: get guest user email from test db, create code, create random password
            string guestEmail = this.testDb.GuestUser.Email;
            string code = "some-code";
            string password = "some-password123";

            // Act:

            // Assert: no exception is thrown with valid user
            Assert.That(
                async() => await this.accountService.ResetPasswordAsync(guestEmail, code, password),
                Throws.Nothing);
        }
    }
}
