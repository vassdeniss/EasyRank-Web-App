// -----------------------------------------------------------------------
// <copyright file="ManageServiceTests.cs" company="Denis Vasilev">
// Copyright (c) Denis Vasilev. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

using System.Security.Claims;
using System.Text;

using EasyRank.Infrastructure.Models.Accounts;
using EasyRank.Services.Contracts;
using EasyRank.Services.Exceptions;
using EasyRank.Services.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

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
                this.mapper);
        }

        [Test]
        public void Test_GetUserInfo_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.GetUserInfoAsync(invalidPrincipal),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetUserInfo_ReturnsCorrectInfo()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act: call service method and pass in necessary data
            ManageServiceModel serviceModel = await this.manageService.GetUserInfoAsync(userPrincipal);

            // Assert: the guest user and service user are the same
            Assert.That(serviceModel.Username, Is.EqualTo(guestUser.UserName));
            Assert.That(serviceModel.FirstName, Is.EqualTo(guestUser.FirstName));
            Assert.That(serviceModel.LastName, Is.EqualTo(guestUser.LastName));
        }

        [Test]
        public void Test_DeleteProfilePicture_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.DeleteProfilePictureAsync(invalidPrincipal),
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

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act: call service method and pass in necessary data
            await this.manageService.DeleteProfilePictureAsync(userPrincipal);

            // Assert: the guest user profile picture has been deleted
            Assert.That(guestUser.ProfilePicture, Is.Null);
        }

        [Test]
        public void Test_UpdateUserData_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async () => await this.manageService.UpdateUserDataAsync(
                    invalidPrincipal,
                    invalidUser.FirstName,
                    invalidUser.LastName, 
                    invalidUser.UserName, 
                    new FormFileCollection()),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesFirstNameSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Arrange: set new first name for user
            string newFistName = "John";

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                userPrincipal,
                newFistName,
                guestUser.LastName,
                guestUser.UserName,
                new FormFileCollection());

            // Assert: the guest user first name has changed
            Assert.That(guestUser.FirstName, Is.EqualTo(newFistName));
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesLastNameSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Arrange: set new last name for user
            string newLastName = "Doe";

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                userPrincipal,
                guestUser.FirstName,
                newLastName,
                guestUser.UserName,
                new FormFileCollection());

            // Assert: the guest user last name has changed
            Assert.That(guestUser.LastName, Is.EqualTo(newLastName));
        }

        [Test]
        public void Test_UpdateUserData_UserNameTaken_ThrowsUsernameTakenException()
        {
            // Arrange: get guest user and denis user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act:

            // Assert: UsernameTakenException is thrown when trying to change to a taken username
            Assert.That(
                async() => await this.manageService.UpdateUserDataAsync(
                    userPrincipal,
                    guestUser.FirstName,
                    guestUser.LastName,
                    denisUser.UserName,
                    new FormFileCollection()),
                Throws.Exception.TypeOf<UsernameTakenException>());
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesUserNameSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Arrange: set new last name for user
            string newUserName = "NewGuest";

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                userPrincipal,
                guestUser.FirstName,
                guestUser.LastName,
                newUserName,
                new FormFileCollection());

            // Assert: the guest user user name has changed
            Assert.That(guestUser.UserName, Is.EqualTo(newUserName));
        }

        [Test]
        public async Task Test_UpdateUserData_InvalidFileExtension_ThrowsFileFormatException()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Arrange: create a fake file with invalid file name / extension
            string invalidFileName = "hacked.exe";
            using MemoryStream stream = new MemoryStream();
            await using StreamWriter writer = new StreamWriter(stream);
            await writer.WriteAsync("Random text");
            await writer.FlushAsync();
            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", invalidFileName);

            // Act:

            // Assert: FileFormatException is thrown when trying to upload an invalid file
            Assert.That(
                async() => await this.manageService.UpdateUserDataAsync(
                    userPrincipal,
                    guestUser.FirstName,
                    guestUser.LastName,
                    guestUser.UserName,
                    new FormFileCollection
                    {
                        file,
                    }),
                Throws.Exception.TypeOf<FileFormatException>());
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesProfilePictureSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Arrange: create a file with valid file name / extension
            string fileName = "picture.jpg";
            using MemoryStream stream = new MemoryStream();
            await using StreamWriter writer = new StreamWriter(stream);
            await writer.WriteAsync("Random text");
            await writer.FlushAsync();
            stream.Position = 0;

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                userPrincipal,
                guestUser.FirstName,
                guestUser.LastName,
                guestUser.UserName,
                new FormFileCollection
                {
                    file,
                });

            // Assert: the guest user profile picture has changed
            Assert.That(guestUser.ProfilePicture, Is.Not.Null);
            
            using MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            Assert.That(guestUser.ProfilePicture, Is.EquivalentTo(memoryStream.ToArray()));
        }

        [Test]
        public async Task Test_UpdateUserData_ChangesAllDataSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Arrange: set new data for user
            string newFistName = "John2";
            string newLastName = "Doe2";
            string newUserName = "NewGuest2";
            string invalidFileName = "picture.jpg";
            using MemoryStream stream = new MemoryStream();
            await using StreamWriter writer = new StreamWriter(stream);
            await writer.WriteAsync("Random text2");
            await writer.FlushAsync();
            stream.Position = 0;
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", invalidFileName);

            // Act: call service method and pass in necessary data
            await this.manageService.UpdateUserDataAsync(
                userPrincipal,
                newFistName,
                newLastName,
                newUserName,
                new FormFileCollection
                {
                    file,
                });

            // Assert: the guest user information has changed
            Assert.That(guestUser.FirstName, Is.EqualTo(newFistName));
            Assert.That(guestUser.LastName, Is.EqualTo(newLastName));
            Assert.That(guestUser.UserName, Is.EqualTo(newUserName));
            Assert.That(guestUser.ProfilePicture, Is.Not.Null);

            using MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            Assert.That(guestUser.ProfilePicture, Is.EquivalentTo(memoryStream.ToArray()));
        }

        [Test]
        public void Test_CheckPassword_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create some kind of password
            string password = "123456abc";

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.CheckPasswordAsync(
                    invalidPrincipal,
                    password),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_CheckPassword_WrongPassword_ReturnsFalse()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Arrange: create invalid password
            string invalidPassword = "thisIsNotMyPassword";

            // Act: call service method and pass in necessary data
            bool result = await this.manageService.CheckPasswordAsync(
                userPrincipal,
                invalidPassword);

            // Assert: the password check failed
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task Test_CheckPassword_CorrectPassword_ReturnsTrue()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act: call service method and pass in necessary data
            string guestPassword = "guestPass";
            bool result = await this.manageService.CheckPasswordAsync(
                userPrincipal,
                guestPassword);

            // Assert: the password check succeeds
            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_DeleteUser_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.DeleteUserAsync(invalidPrincipal),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_DeleteUser_ValidClaimPrincipal_RemovesSuccessfully()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;
            string guestUserName = guestUser.UserName;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act: call service method
            await this.manageService.DeleteUserAsync(userPrincipal);

            // Assert: user is deleted
            Assert.That(guestUser.UserName, Is.EqualTo($"DELETED{guestUserName}"));
        }

        [Test]
        public void Test_IsEmailConfirmed_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.IsEmailConfirmedAsync(invalidPrincipal),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_IsEmailConfirmed_NotConfirmed_ReturnsFalse()
        {
            // Arrange: get denis user from test db
            EasyRankUser denisUser = this.testDb.DenisUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(denisUser);

            // Act: call service method and pass in necessary data
            bool result = await this.manageService.IsEmailConfirmedAsync(userPrincipal);

            // Assert: the email is not confirmed
            Assert.That(result, Is.False);
        }

        [Test]
        public async Task Test_IsEmailConfirmed_IsConfirmed_ReturnsTrue()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act: call service method and pass in necessary data
            bool result = await this.manageService.IsEmailConfirmedAsync(userPrincipal);

            // Assert: the email is confirmed
            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_GetUserEmail_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.GetUserEmailAsync(invalidPrincipal),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetUserEmail_ReturnsCorrectEmail()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a new claim principal from the user
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act: call service method and pass in necessary data
            EmailServiceModel serviceResult = await this.manageService.GetUserEmailAsync(userPrincipal);

            // Assert: the email is correct
            Assert.That(serviceResult.Email, Is.EqualTo(guestUser.Email));
            Assert.That(serviceResult.NewEmail, Is.EqualTo(guestUser.Email));
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
        public void Test_GetUserId_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.GetUserIdAsync(invalidPrincipal),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GetUserId_ReturnsCorrectId()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a valid claim principal
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Act: call service method and pass in necessary data
            string id = await this.manageService.GetUserIdAsync(userPrincipal);

            // Assert: both ids are the same
            Assert.That(id, Is.EqualTo(guestUser.Id.ToString()));
        }

        [Test]
        public void Test_GenerateChangeEmailToken_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.GenerateChangeEmailTokenAsync(invalidPrincipal, invalidUser.Email),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GenerateChangeEmailToken_GeneratesCorrectly()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a valid claim principal
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Arrange: create sample code
            string expectedCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes("random-string"));

            // Act: call service method and pass in necessary data
            string actualCode = await this.manageService.GenerateChangeEmailTokenAsync(userPrincipal, guestUser.Email);

            // Assert: both codes are the same
            Assert.That(actualCode, Is.EqualTo(expectedCode));
        }

        [Test]
        public void Test_GenerateEmailConfirmationToken_InvalidClaimPrincipal_ThrowsNotFoundException()
        {
            // Arrange: create an invalid user
            EasyRankUser invalidUser = new EasyRankUser
            {
                Id = Guid.NewGuid(),
                Email = "testManage@mail.com",
                FirstName = "test",
                LastName = "manage",
                UserName = "TestManage",
            };

            // Arrange: create an invalid claim principal
            ClaimsPrincipal invalidPrincipal = this.CreateClaimsPrincipal(invalidUser);

            // Act:

            // Assert: NotFoundException is thrown with invalid id
            Assert.That(
                async() => await this.manageService.GenerateEmailConfirmationTokenAsync(invalidPrincipal),
                Throws.Exception.TypeOf<NotFoundException>());
        }

        [Test]
        public async Task Test_GenerateEmailConfirmationToken_GeneratesCorrectly()
        {
            // Arrange: get guest user from test db
            EasyRankUser guestUser = this.testDb.GuestUser;

            // Arrange: create a valid claim principal
            ClaimsPrincipal userPrincipal = this.CreateClaimsPrincipal(guestUser);

            // Arrange: create sample code
            string expectedCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes("random-string"));

            // Act: call service method and pass in necessary data
            string actualCode = await this.manageService.GenerateEmailConfirmationTokenAsync(userPrincipal);

            // Assert: both codes are the same
            Assert.That(actualCode, Is.EqualTo(expectedCode));
        }

        private ClaimsPrincipal CreateClaimsPrincipal(EasyRankUser user)
        {
            List<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userClaims);

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
