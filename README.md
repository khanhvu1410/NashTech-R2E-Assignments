# R2E Assignments - Khanh Vu

## Overview  
This repository contains a collection of assignments completed as part of the Rookie to Engineer (R2E) program at NashTech. The projects span various stages of learning, starting from basic C# fundamentals to building full-stack applications using ASP.NET Core.

## Topics covered:
- C# Fundamentals
- ASP.NET Core Fundamentals
- ASP.NET Core MVC
- ASP.NET Core Web API
- Entity Framework Core

## Architectures used in assignments

### N-tier: ASP.NET Core MVC Assignment
```bash
MvcAssignment
├───MvcAssignment.Business
│   ├───Interfaces
│   └───Services
├───MvcAssignment.Data
│   ├───Interfaces
│   ├───Models
│   └───Repositories
├───MvcAssignment.Shared
│   ├───DTOs
│   └───Enums
└───MvcAssignment.Web
    ├───Controllers
    ├───Enums
    ├───Models
    ├───Views
    │   ├───Home
    │   ├───Rookies
    │   └───Shared
    └───wwwroot
```

### Clean Architecture:
- ToDo API Assignment
- Person API Assignment
- EF Core Assignment Day 1
```bash
PersonApiAssignment
├───Core
│   ├───PersonApiAssignment.Application
│   │   ├───DTOs
│   │   ├───Interfaces
│   │   ├───Mappings
│   │   └───Services
│   └───PersonApiAssignment.Domain
│       ├───Entities
│       ├───Enums
│       └───Interfaces
├───Infrastructure
│   └───PersonApiAssignment.Persistence
│       ├───Data
│       ├───Interfaces
│       └───Repositories
└───Presentation
    └───PersonApiAssignment.Api
        ├───Controllers
        └───Filters
```

## Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or Visual Studio Code

## How to run the assignments

### Step 1: Clone the repository  
Open a terminal or command prompt and run the following command:
```sh
git clone https://github.com/khanhvu1410/NashTech-R2E-Assignments.git
```
Navigate to the root folder:
```sh
cd NashTech-R2E-Assignments
```

### Step 2: Navigate to the desired assignment
**For C# Fundamentals Assignment Day 1:**
```sh
cd AssignmentDay1/AssignmentDay1
```
**For C# Fundamentals Assignment Day 2:**
```sh
cd AssignmentDay2/AssignmentDay2
```
**For ASP.NET Core Fundamentals Middleware Assignment:**
- Ensure that you provide a valid endpoint to process HTTP requests and generate logs in logs.txt
- Example: http://localhost:5110/Cars/FilterByModel?model=Mustang
```sh
cd MiddlewareAssignment/MiddlewareAssignment
```
**For ASP.NET Core MVC Assignment:**
```sh
cd MvcAssignment/MvcAssignment.Web
```
**For ToDo API Assignment:**
```sh
cd ToDoApiAssignment/Presentation/ToDoApiAssignment.Api
```
**For Person API Assignment:**
```sh
cd PersonApiAssignment/Presentation/PersonApiAssignment.Api
```
**For EF Core Assignment Day 1:**
```sh
cd EfCoreAssignmentDay1
```
**For EF Core Assignment Day 2:**
```sh
cd EfCoreAssignmentDay2/EfCoreAssignmentDay2.Api
```

### Step 3: Run the application 
Inside the respective folder, execute:
```sh
dotnet run
```
**For EF Core Assignment Day 1 (2):**
- Change connection string in appsettings.json:
```json
"ConnectionStrings": {
  "EFCoreDBConnection": "Server=YourSQLServerName;Database=EfCoreAssignment;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
- Add a migration:
```sh
dotnet ef migrations add InitialCreate --project Infrastructure/EfCoreAssignmentDay1.Persistence --startup-project Presentation/EfCoreAssignmentDay1.Api 
```
- Apply the migration to the database:
```sh
dotnet ef database update --project Infrastructure/EfCoreAssignmentDay1.Persistence --startup-project Presentation/EfCoreAssignmentDay1.Api
```