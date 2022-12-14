// -----------------------------------------------------------------------
// <copyright file="ManageServiceTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Text;

using EasyRank.Infrastructure.Models;
using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace EasyRank.Services.UnitTests
{
    [TestFixture]
    public class ManageServiceTests : UnitTestBase
    {
        private IManageService manageService;

        [SetUp]
        public void SetUp()
        {
            this.manageService = new ManageService(
                this.userManager.Object, 
                this.signInManager.Object,
                this.mapper,
                this.repo);
        }

        [Test]
        public void Test_GetUserInfo_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.GetUserInfoAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetUserInfo_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.manageService.GetUserInfoAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetUserInfo_ReturnsCorrectInfo()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Act: call service method and pass in necessary data
            ManageServiceModel serviceModel = await this.manageService.GetUserInfoAsync(denisUser.Id);

            // Assert: the guest user and service user are the same
            Assert.That(serviceModel.Username, Is.EqualTo(denisUser.UserName));
            Assert.That(serviceModel.FirstName, Is.EqualTo(denisUser.FirstName));
            Assert.That(serviceModel.LastName, Is.EqualTo(denisUser.LastName));
        }

        [Test]
        public void Test_DeleteProfilePicture_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.DeleteProfilePictureAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_DeleteProfilePicture_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.manageService.DeleteProfilePictureAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_DeleteProfilePicture_RemovesCorrectly()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;
            
            // Arrange: put an empty byte array on the guest user
            guestUser.ProfilePicture = Array.Empty<byte>();
            await this.repo.SaveChangesAsync();
            Assert.That(guestUser.ProfilePicture, Is.Not.Null);

            // Act: call service method and pass in necessary data
            await this.manageService.DeleteProfilePictureAsync(guestUser.Id);

            // Assert: the guest user profile picture has been deleted
            Assert.That(guestUser.ProfilePicture, Is.Null);
        }

        [Test]
        public void Test_UpdateUserData_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.manageService.UpdateUserDataAsync(
                    Guid.NewGuid(),
                    string.Empty,
                    string.Empty, 
                    string.Empty, 
                    new FormFileCollection()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesFirstNameSuccessfully()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: set new first name for user
            string newFistName = "John";

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                denisUser.Id,
                newFistName,
                denisUser.LastName,
                denisUser.UserName,
                new FormFileCollection());

            // Assert: the denis user first name has changed
            Assert.That(denisUser.FirstName, Is.EqualTo(newFistName));
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesLastNameSuccessfully()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: set new last name for user
            string newLastName = "Doe";

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                denisUser.Id,
                denisUser.FirstName,
                newLastName,
                denisUser.UserName,
                new FormFileCollection());

            // Assert: the guest user last name has changed
            Assert.That(denisUser.LastName, Is.EqualTo(newLastName));
        }

        [Test]
        public void Test_UpdateUserData_UserNameTaken_ThrowsUsernameTakenException()
        {
            // Arrange: get denis user and liked user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;
            EasyRankUser likedUser = this.testDb.LikedUser;

            // Act:

            // Assert: UsernameTakenException is thrown when trying to change to a taken username
            Assert.That(
                async() => await this.manageService.UpdateUserDataAsync(
                    denisUser.Id,
                    denisUser.FirstName,
                    denisUser.LastName,
                    likedUser.UserName,
                    new FormFileCollection()),
                Throws.Exception.TypeOf<UsernameTakenException>());
        }

        [Test]
        public void Test_UpdateUserData_UserForgotten_ThrowsUsernameTakenException()
        {
            // Arrange: get denis user and forgotten user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: UsernameTakenException is thrown when trying to change to a taken username
            Assert.That(
                async () => await this.manageService.UpdateUserDataAsync(
                    denisUser.Id,
                    denisUser.FirstName,
                    denisUser.LastName,
                    forgottenUser.UserName,
                    new FormFileCollection()),
                Throws.Exception.TypeOf<UsernameTakenException>());
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesUserNameSuccessfully()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: set new last name for user
            string newUserName = "NewGuest";

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                denisUser.Id,
                denisUser.FirstName,
                denisUser.LastName,
                newUserName,
                new FormFileCollection());

            // Assert: the guest user user name has changed
            Assert.That(denisUser.UserName, Is.EqualTo(newUserName));
        }

        [Test]
        public void Test_UpdateUserData_InvalidFileExtension_ThrowsFileFormatException()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: create a fake file with invalid file name / extension
            byte[] bytes = Encoding.UTF8.GetBytes("Dummy File");
            IFormFile file = new FormFile(
                new MemoryStream(bytes),
                0,
                bytes.Length,
                "Data",
                "appsettings.json");

            // Act:

            // Assert: FileFormatException is thrown when trying to upload an invalid file
            Assert.That(
                async() => await this.manageService.UpdateUserDataAsync(
                    denisUser.Id,
                    denisUser.FirstName,
                    denisUser.LastName,
                    denisUser.UserName,
                    new FormFileCollection
                    {
                        file,
                    }),
                Throws.Exception.TypeOf<FileFormatException>());
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesProfilePictureSuccessfully()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: create a file with valid file name / extension
            byte[] bytes = Encoding.UTF8.GetBytes("Dummy File");
            IFormFile file = new FormFile(
                new MemoryStream(bytes),
                0,
                bytes.Length,
                "Data",
                "avatar.jpg");

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                denisUser.Id,
                denisUser.FirstName,
                denisUser.LastName,
                denisUser.UserName,
                new FormFileCollection
                {
                    file,
                });

            // Assert: the denis user profile picture has changed
            Assert.That(denisUser.ProfilePicture, Is.Not.Null);
            
            using MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            Assert.That(denisUser.ProfilePicture, Is.EquivalentTo(memoryStream.ToArray()));
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesAllDataSuccessfully()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: set new data for user
            string newFistName = "John2";
            string newLastName = "Doe2";
            string newUserName = "NewGuest2";
            byte[] bytes = Encoding.UTF8.GetBytes("Dummy File");
            IFormFile file = new FormFile(
                new MemoryStream(bytes),
                0,
                bytes.Length,
                "Data",
                "avatar.png");

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                denisUser.Id,
                newFistName,
                newLastName,
                newUserName,
                new FormFileCollection
                {
                    file,
                });

            // Assert: the denis user information has changed
            Assert.That(denisUser.FirstName, Is.EqualTo(newFistName));
            Assert.That(denisUser.LastName, Is.EqualTo(newLastName));
            Assert.That(denisUser.UserName, Is.EqualTo(newUserName));
            Assert.That(denisUser.ProfilePicture, Is.Not.Null);

            using MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            Assert.That(denisUser.ProfilePicture, Is.EquivalentTo(memoryStream.ToArray()));
        }

        [Test]
        public void Test_CheckPassword_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange: create some kind of password
            string password = "123456abc";

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.CheckPasswordAsync(
                    Guid.NewGuid(), 
                    password),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_CheckPassword_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async () => await this.manageService.CheckPasswordAsync(
                    forgottenUser.Id,
                    "123"),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_CheckPassword_WrongPassword_ReturnsFalse()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create invalid password
            string invalidPassword = "thisIsNotMyPassword";

            // Act: call service method and pass in necessary data
            bool result = await this.manageService.CheckPasswordAsync(
                guestUser.Id,
                invalidPassword);

            // Assert: the password check failed
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task Test_CheckPassword_CorrectPassword_ReturnsTrue()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Act: call service method and pass in necessary data
            string denisPassword = "myVeryCoolPassword";
            bool result = await this.manageService.CheckPasswordAsync(
                denisUser.Id,
                denisPassword);

            // Assert: the password check succeeds
            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_DeleteUser_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.DeleteUserAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_DeleteUser_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async() => await this.manageService.DeleteUserAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_DeleteUser_ValidUserId_RemovesSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Act: call service method
            await this.manageService.DeleteUserAsync(guestUser.Id);

            // Assert: user ranks are deleted
            List<RankPage> userPages = await this.repo.AllReadonly<RankPage>(
                    rp => rp.CreatedByUserId == guestUser.Id && !rp.IsDeleted)
                .Include(rp => rp.Entries)
                .Include(rp => rp.Comments)
                .ToListAsync();

            Assert.That(userPages.Count, Is.Zero);

            // Assert: user rank entries, comments are deleted
            foreach (RankPage page in userPages)
            {
                Assert.That(page.Entries.Count, Is.Zero);
                Assert.That(page.Comments.Count, Is.Zero);
            }

            // Assert: user comments are deleted
            List<Comment> userComments = await this.repo.AllReadonly<Comment>(
                    c => c.CreatedByUserId == guestUser.Id && !c.IsDeleted)
                .ToListAsync();

            Assert.That(userComments.Count, Is.Zero);

            // Assert: user is deleted
            Assert.That(guestUser.IsForgotten, Is.True);
        }

        [Test]
        public void Test_IsEmailConfirmed_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.IsEmailConfirmedAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_IsEmailConfirmed_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.IsEmailConfirmedAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_IsEmailConfirmed_NotConfirmed_ReturnsFalse()
        {
            // Arrange: get liked user from test db
            EasyRankUser likedUser = this.testDb.LikedUser;

            // Act: call service method and pass in necessary data
            bool result = await this.manageService.IsEmailConfirmedAsync(likedUser.Id);

            // Assert: the email is not confirmed
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task Test_IsEmailConfirmed_IsConfirmed_ReturnsTrue()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Act: call service method and pass in necessary data
            bool result = await this.manageService.IsEmailConfirmedAsync(denisUser.Id);

            // Assert: the email is confirmed
            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_GetUserEmail_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.GetUserEmailAsync(Guid.NewGuid()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_GetUserEmail_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.manageService.GetUserEmailAsync(forgottenUser.Id),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetUserEmail_ReturnsCorrectEmail()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Act: call service method and pass in necessary data
            EmailServiceModel serviceResult = await this.manageService.GetUserEmailAsync(denisUser.Id);

            // Assert: the email is correct
            Assert.That(serviceResult.Email, Is.EqualTo(denisUser.Email));
            Assert.That(serviceResult.NewEmail, Is.EqualTo(denisUser.Email));
        }

        [Test]
        public async Task Test_IsEmailTaken_TakenEmail_ReturnsTrue()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Act: call service method and pass in necessary data
            bool isTaken = await this.manageService.IsEmailTakenAsync(guestUser.Email);

            // Assert: email is taken
            Assert.That(isTaken, Is.True);
        }

        [Test]
        public async Task Test_IsEmailTaken_NotTakenEmail_ReturnsFalse()
        {
            // Arrange: create imaginary email
            string email = "IDontExist@null.undefined";

            // Act: call service method and pass in necessary data
            bool isTaken = await this.manageService.IsEmailTakenAsync(email);

            // Assert: email is not taken
            Assert.That(isTaken, Is.False);
        }

        [Test]
        public void Test_GenerateChangeEmailToken_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.GenerateChangeEmailTokenAsync(
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
                async () => await this.manageService.GenerateChangeEmailTokenAsync(forgottenUser.Id, "RandomEmail"),
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
            string actualCode = await this.manageService.GenerateChangeEmailTokenAsync(denisUser.Id, denisUser.Email);

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
                async() => await this.manageService.GenerateEmailConfirmationTokenAsync(Guid.NewGuid()),
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
                async () => await this.manageService.GenerateEmailConfirmationTokenAsync(forgottenUser.Id),
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
            string actualCode = await this.manageService.GenerateEmailConfirmationTokenAsync(denisUser.Id);

            // Assert: both codes are the same
            Assert.That(actualCode, Is.EqualTo(expectedCode));
        }

        [Test]
        public void Test_ChangeEmail_InvalidId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.ChangeEmailAsync(
                    Guid.NewGuid(),
                    "email-test@mail.com",
                    "some-code"),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_ChangeEmail_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async () => await this.manageService.ChangeEmailAsync(
                    forgottenUser.Id,
                    "email-test@mailcom",
                    "some-code"),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_ChangeEmail_ChangesSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: make new email and code
            string email = "email-test@mail.com";
            string code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes("random-string"));

            // Act: call service method and pass in necessary data
            IdentityResult result = await this.manageService.ChangeEmailAsync(guestUser.Id, email, code);

            // Assert: identity result is successful, and user has new email
            Assert.That(result, Is.EqualTo(IdentityResult.Success));
            Assert.That(guestUser.Email, Is.EqualTo(email));
        }

        [Test]
        public void Test_ConfirmEmail_InvalidId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.ConfirmEmailAsync(Guid.NewGuid(), "some-code"),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_ConfirmEmail_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async () => await this.manageService.ConfirmEmailAsync(forgottenUser.Id, "some-code"),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_ConfirmEmail_ConfirmsSuccessfully()
        {
            // Arrange: get unconfirmed user from test db
            EasyRankUser unconfirmedUser = this.testDb.UnconfirmedUser;

            // Arrange: make code
            string code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes("random-string"));

            // Act: call service method and pass in necessary data
            IdentityResult result = await this.manageService.ConfirmEmailAsync(unconfirmedUser.Id, code);

            // Assert: identity result is successful, and user has confirmed email
            Assert.That(result, Is.EqualTo(IdentityResult.Success));
            Assert.That(unconfirmedUser.EmailConfirmed, Is.True);
        }

        [Test]
        public void Test_ChangePassword_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.ChangePasswordAsync(
                    Guid.NewGuid(),
                    "123", 
                    "321"),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public void Test_ChangePassword_ForgottenUser_ThrowsNotFoundException()
        {
            // Arrange: get forgotten user from test db
            EasyRankUser forgottenUser = this.testDb.ForgottenUser;

            // Act:

            // Assert: NotFoundException is thrown with forgotten user
            Assert.That(
                async () => await this.manageService.ChangePasswordAsync(
                    forgottenUser.Id,
                    "123",
                    "321"),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_ChangePassword_ChangesSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;
            string oldHash = guestUser.PasswordHash;

            // Arrange: set old pass, create new password
            string oldPass = "guestPass";
            string newPass = "1234567abc";

            // Act: call service method and pass in necessary data
            IdentityResult result = await this.manageService.ChangePasswordAsync(guestUser.Id, oldPass, newPass);

            // Assert: identity result is successful, and user has changed password
            Assert.That(result, Is.EqualTo(IdentityResult.Success));
            Assert.That(guestUser.PasswordHash, Is.Not.EqualTo(oldHash));
        }

        [Test]
        public void Test_GetUserIdByEmail_InvalidUserId_ThrowsNotFoundException()
        {
            // Arrange:

            // Act:

            // Assert: NotFoundException is thrown with invalid email
            Assert.That(
                async() => await this.manageService.GetUserIdByEmail(string.Empty),
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
                async() => await this.manageService.GetUserIdByEmail(forgottenUser.Email),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetUserIdByEmail_ReturnsCorrectId()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Act: call service method and pass in necessary data
            Guid id = await this.manageService.GetUserIdByEmail(denisUser.Email);

            // Assert: both ids are the same
            Assert.That(id, Is.EqualTo(denisUser.Id));
        }
    }
}
