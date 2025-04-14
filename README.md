# R2E Assignments - Khanh Vu

## Overview  
This repository contains a collection of assignments completed as part of the Rookie to Engineer (R2E) program at NashTech. The projects span various stages of learning, starting from basic C# fundamentals to building full-stack applications using ASP.NET Core.

## Topics covered:
- C# Fundamentals
- ASP.NET Core Fundamentals
- ASP.NET Core MVC
- ASP.NET Core Web API
- Entity Framework Core
- Unit Testing with NUnit

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
- EF Core Assignment Day 2
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
Open a terminal and run:
```sh
git clone https://github.com/khanhvu1410/NashTech-R2E-Assignments.git
cd NashTech-R2E-Assignments
```

### Step 2: Navigate to the desired assignment
**C# Fundamentals Assignment**
- Day 1:
```sh
cd AssignmentDay1/AssignmentDay1
```
- Day 2:
```sh
cd AssignmentDay2/AssignmentDay2
```
**ASP.NET Core Fundamentals Middleware Assignment**
- Ensure that you provide a valid endpoint to process HTTP requests and generate logs in logs.txt
- Example: http://localhost:5110/Cars/FilterByModel?model=Mustang
```sh
cd MiddlewareAssignment/MiddlewareAssignment
```
**ASP.NET Core MVC & Unit Testing Assignment**
```sh
cd MvcAssignment
```
- To run unit tests:
```sh
dotnet test
```
- To run the MVC app:
```sh
cd MvcAssignment/MvcAssignment.Web
```
**ToDo API Assignment**
```sh
cd ToDoApiAssignment/Presentation/ToDoApiAssignment.Api
```
**Person API Assignment**
```sh
cd PersonApiAssignment/Presentation/PersonApiAssignment.Api
```
**EF Core Assignment Day 1**
```sh
cd EfCoreAssignmentDay1
```
- Update appsettings.json with your SQL Server connection string:
```json
"ConnectionStrings": {
  "EFCoreDBConnection": "Server=YourSQLServerName;Database=EfCoreAssignment;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
- Apply migrations:
```sh
dotnet ef database update --project Infrastructure/EfCoreAssignmentDay1.Persistence --startup-project Presentation/EfCoreAssignmentDay1.Api
```
**EF Core Assignment Day 2**
```sh
cd EfCoreAssignmentDay2
```
- Apply migrations:
```sh
dotnet ef database update --project EfCoreAssignmentDay2.Persistence --startup-project EfCoreAssignmentDay2.Api
```
- To test the APIs:
```sh
cd EfCoreAssignmentDay2.Api
```

### Step 3: Run the application 
From the assignment's root directory:
```sh
dotnet run
```