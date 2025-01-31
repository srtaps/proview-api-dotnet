# Product Review API

This C# API project was developed as part of a college assignment for a course, using .NET 8. The API allows users to manage accounts, log in, view products and their reviews, as well as create, edit, and delete them. The purpose of this project is to demonstrate basic API functionality with authentication, CRUD operations, and database interaction (filtering, pagination, sorting, and management of foreign key relationships).

### Prerequisites

- .NET 8 SDK
- Visual Studio
- SQL Server/SSMS

### Instructions

- Open ```ProductReviewAPI.sln```
- Build > Clean solution
- In ```appsettings.json``` replace ```PC_NAME``` (example DESKTOP-ABC123D) and ```DB_NAME```. The connection string is using Windows Authentication
- Tools > NuGet Package Manager > Package Manager Console
- Run the commands ```Add-Migration init``` and ```Update-Database```

##
![API routes in Swagger](swagger.png)
