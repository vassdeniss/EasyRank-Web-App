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
![login-page](https://user-images.githubusercontent.com/72888249/207841909-1c9b29d3-2fe8-4db9-a1d7-7844227c9a81.png)
![register-page](https://user-images.githubusercontent.com/72888249/207842008-87cc088a-a262-479c-bf5e-8c5dc08b43b3.png)
![main-page-logged-in](https://user-images.githubusercontent.com/72888249/208267217-98898203-c37e-461e-8143-63219c494686.png)
![main-page-admin](https://user-images.githubusercontent.com/72888249/207842314-9f94db64-4c95-4290-8cad-d8530d30c17a.png)
![admin-all-ranks](https://user-images.githubusercontent.com/72888249/208267127-a4187a44-b0f4-4cdf-989b-a7ecd2e9331b.png)
![admin-all-entries](https://user-images.githubusercontent.com/72888249/208267115-7cbefe4d-5853-4e4f-86da-a27f2df62fe8.png)
![admin-all-comments](https://user-images.githubusercontent.com/72888249/208267142-206f24ab-c9f5-400b-9891-04e5b1ea8552.png)
![admin-all-users](https://user-images.githubusercontent.com/72888249/208267179-8bcae0ad-f074-412d-b081-fe43c01821f2.png)
![account-confirm-page](https://user-images.githubusercontent.com/72888249/207842105-10f5c203-a2ac-479b-abea-740a8308021b.png)
![forgot-password-page](https://user-images.githubusercontent.com/72888249/207842127-c4c20f76-742d-4224-8a9e-53a3d6d72dcc.png)
![edit-own-rank](https://user-images.githubusercontent.com/72888249/208267244-fe26b2be-40b2-4449-9407-a02d0c2968be.png)
![delete-own-rank](https://user-images.githubusercontent.com/72888249/208267251-44e81e80-5d00-4d85-a9ca-be5af7ffea9e.png)
![all-ranks](https://user-images.githubusercontent.com/72888249/208266573-9f3b5bf0-46fd-4032-bc57-7ba9879820cc.png)
![edit-rank](https://user-images.githubusercontent.com/72888249/208266584-e636f459-73f0-424b-926b-2109ff1334a6.png)
![delete-rank](https://user-images.githubusercontent.com/72888249/208266594-9ea25fad-b454-4bf3-bc71-25572e010783.png)
![rank-page-one](https://user-images.githubusercontent.com/72888249/208266662-2fc02ebb-2c8d-486e-af38-160e06ea77d9.png)
![rank-page-two](https://user-images.githubusercontent.com/72888249/208266680-da8634bb-6d25-418c-a455-1b27f290acd9.png)
![edit-entry](https://user-images.githubusercontent.com/72888249/208266712-12ed9cb9-5ae0-4c5e-9a26-8a9ac993f13b.png)
![delete-entry](https://user-images.githubusercontent.com/72888249/208266741-7bcf88af-22aa-41ca-8df7-6c96eb81c0ca.png)
![comments](https://user-images.githubusercontent.com/72888249/208266699-b54de778-398f-47d8-aa62-11edf5438ae1.png)
![comment-edit](https://user-images.githubusercontent.com/72888249/208266764-da90614a-bb33-4660-ae59-480757529ca4.png)
![commend-delete](https://user-images.githubusercontent.com/72888249/208266778-848159c1-d5b1-44f0-896e-62a57e3adff8.png)
![account-settings](https://user-images.githubusercontent.com/72888249/207842477-8c3fbb1e-1b58-4e68-9ee4-c628fd0df17a.png)
![change-email](https://user-images.githubusercontent.com/72888249/207842503-85ac5029-57e8-456f-ac4d-2dfcde58f602.png)
![change-password](https://user-images.githubusercontent.com/72888249/207842548-a2555847-9f98-4126-82e4-ab748d7c4983.png)
![my-ranks](https://user-images.githubusercontent.com/72888249/208267272-16606ebd-340b-4af4-a7fd-b3ac18d7990d.png)
![my-likes](https://user-images.githubusercontent.com/72888249/208267284-5d54c43a-d0d4-4171-81eb-3d97ca566c6f.png)

## :clipboard: Test Coverage
![test-coverage](https://user-images.githubusercontent.com/72888249/208266194-549cdd55-0f0b-460c-b522-2fa4c503d2ea.png)

## :wrench: DB Diagram
![db-diagram](https://user-images.githubusercontent.com/72888249/207841550-71d596fa-59df-4b00-9ad0-b6e97f8e7696.png)
