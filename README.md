# Easy-Rank-Web-App

## The "EasyRank" Web App

**EasyRank** - defense project for [**ASP.NET Advanced**](https://softuni.bg/trainings/3854/asp-net-advanced-october-2022) course at [SoftUni](https://softuni.bg/ "SoftUni") (October 2022).

## :pencil2: Overview

**Easy Rank** is a website for creating rank type pages.

Users can **view / create / edit / delete** 'Rank Pages' which contain N number of 'Rank Entries' for the specified topic.

Users can also comment on these pages and leave a like on them if desired.

- All users can browse the site freely.
- All authorized users can leave comments, like the page or create their own ranking.
- Liked pages, created pages, and comments are saved for authorized users
- Pages / entries / comments may be edited or deleted only by their creator or by the administrator.

## :performing_arts: User Types

**Administrator** - created from site owner – username: “admin@mail.com”, password: “pass123#”

- Create, read, edit, delete and finish all goals on the site (the administrator is a creator).
- Work on all unfinished goals and see their own goal works.
- Comment on goals.
- See all goal works.
- See all users.
- See all comments.

**Creator** - logged-in user, who has become a creator through the “Become a Creator” functionality and has a “creator name”

- Read all goals on the site.
- Create goals and edit, delete and finish them. Creators can manage only goals they created!
- Comment on goals.
- See their own goal works from the time before they became a creator.
- Creators cannot work on any goals!

**User** - logged-in user, who is not a creator

- Read all goals on the site.
- Work on all goals and see their own goal works.
- Comment on goals.
- Can become a creator.

## :hammer: Built With

- ASP.NET Core 6
  - 5 controllers + 5 more in the “Admin” area
  - 6 entity models
  - Service layer
  - Test layer
  - 11 views + 4 more in the “Admin” area + partial views
  - View and form models
  - etc.
- Entity Framework Core
- Microsoft SQL Server
- AutoMapper
- TempData messages
- jQuery
- NUnit

## :clipboard: Test Coverage

## :wrench: DB Diagram
