# Easy-Rank-Web-App

## The "EasyRank" Web App

**EasyRank** - defense project for [**ASP.NET Advanced**](https://softuni.bg/trainings/3854/asp-net-advanced-october-2022) course at [SoftUni](https://softuni.bg/ "SoftUni") (October 2022).

## :pencil2: Overview

**Easy Rank** is a website for creating rank type pages.

Users can **view / create / edit / delete** 'Rank Pages' which contain N number of 'Rank Entries' for the specified topic.

Users can also comment on these pages and leave a like on them if desired.

- All users can browse the site freely
- All authorized users can leave comments, like the page or create their own ranking
- Authorized users can change their password, email, names, username and avatars (includes emails with **SendGrid**)
- Liked pages, created pages, and comments are saved for authorized users
- Pages / entries / comments may be edited or deleted only by their creator or by the administrator
- Administrators have full access to the site. Editing deleting pages or entries or comments or even users. Admins can make other users admins

## :performing_arts: User Types

**Administrator** - user with privileges

- Create, read, edit, delete all pages, entries, comments or users on the site
- See all ranks
- See all entries
- See all comments
- See all users

**User** - logged-in user

- Create pages, entries or comments and edit or delete them.
- Users can manage only content they created!
- Exception with comments on their page - those can be deleted if innappropriate content is posted

**Anonymous** - users without an account

- Read all pages on the site.

## :hammer: Built With

- ASP.NET Core 6
  - Database layer wtih 4 entity models
  - UI layer with 7 controllers + 6 more in the “Admin” area
  - Service layer with 7 services
  - Test layer for services and controllers with 200+ tests
  - 40 views + 9 partial views
- Entity Framework Core
- Microsoft SQL Server
- AutoMapper
- TempData messages
- NUnit
- SendGrid for emails
- Working deploy to [Azure](https://easyrank.azurewebsites.net)

## :camera_flash: Screenshots
![main-page-not-logged-in](https://user-images.githubusercontent.com/72888249/207841839-3c9ac9bd-0156-473d-b6ac-dc0deb18a52d.png)
![main-page-admin](https://user-images.githubusercontent.com/72888249/207842314-9f94db64-4c95-4290-8cad-d8530d30c17a.png)
![login-page](https://user-images.githubusercontent.com/72888249/207841909-1c9b29d3-2fe8-4db9-a1d7-7844227c9a81.png)
![register-page](https://user-images.githubusercontent.com/72888249/207842008-87cc088a-a262-479c-bf5e-8c5dc08b43b3.png)
![account-confirm-page](https://user-images.githubusercontent.com/72888249/207842105-10f5c203-a2ac-479b-abea-740a8308021b.png)
![forgot-password-page](https://user-images.githubusercontent.com/72888249/207842127-c4c20f76-742d-4224-8a9e-53a3d6d72dcc.png)
![image](https://user-images.githubusercontent.com/72888249/207842477-8c3fbb1e-1b58-4e68-9ee4-c628fd0df17a.png)
![change-email](https://user-images.githubusercontent.com/72888249/207842503-85ac5029-57e8-456f-ac4d-2dfcde58f602.png)
![change-password](https://user-images.githubusercontent.com/72888249/207842548-a2555847-9f98-4126-82e4-ab748d7c4983.png)

## :clipboard: Test Coverage

## :wrench: DB Diagram
![db-diagram](https://user-images.githubusercontent.com/72888249/207841550-71d596fa-59df-4b00-9ad0-b6e97f8e7696.png)
