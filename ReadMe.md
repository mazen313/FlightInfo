# FlightInfo

FlightInfo is a sample application built using ASP.NET Core and Entity Framework Core.



## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
 
  2. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution 

  4. Next, set Src\Core\MigrationApp as startup project

  5. Change the connection string in appsettings.json file of MigrationApp project (currently using sql express) -- NB: Connection string should be the same in the projects FlightInfo.WebApi, FlightInfo.Reporting, MigrationApp

  6. Open Package Manager Console and run the following command after setting the Default Project in the ackage Manager Console as Src\Infrastructure\FlightInfo.Persistence:
	```
	Update-database
	```
  7. Set the following projects as startup: FlightInfo.WebApi, FlightInfo.Reporting, FlightInfo.WebUI

  8. If you're running the project on a 32 bits computer, please replace the files in the FlightInfo.Reporting\wwwroot\Rotativa



## Technologies
* .NET Core 2.2
* ASP.NET Core 2.2
* Entity Framework Core 2.2