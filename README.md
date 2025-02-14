# Product Review API

A C# Web API example using .NET 8 that demonstrates. Functionality includes user account management, login, CRUD operations for creating, viewing, editing, and deleting records. The project showcases API features like authentication, database interaction (with filtering, pagination, sorting), along with using repositories, interfaces, mappers and other C# design patterns.

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
