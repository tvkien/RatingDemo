# RatingDemo
This repository to perform the test of ALT Technology company

# IDE and Framework required
- .NET Core SDK 3.1
- Visual Studio 2019
- SQL Server 2017/2019
- Git Client

# Steps to run
- Update the connection string in appsettings.json in RatingDemo.Data and RatingDemo.BackendApi.
- Migrate-Database
	. Set as Startup Project for RatingDemo.Data project.
	. Open Package Manager Console and type "Update-Database" then Enter.
- Set multiproject to start in solution:
	. First is RatingDemo.BackendApi
	. Second is RatingDemo.WebApp
- The passcode default is "admin"

# Technologies and frameworks used:
- ASP.NET MVC Core 3.1
- Entity Framework Core 3.1
- ASP.NET Identity Core 3.1
- Bootstrap 4.4.1