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

## Screenshots

## :clipboard: Test Coverage

## :wrench: DB Diagram
