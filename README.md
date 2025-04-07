# R2E Assignments - Khanh Vu

## Overview  
This repository contains a collection of assignments completed as part of the Rookie to Engineer (R2E) program at NashTech. The projects span various stages of learning, starting from basic C# fundamentals to building full-stack applications using ASP.NET Core.

## Topics covered:
- C# Fundamentals
- ASP.NET Core Fundamentals
- ASP.NET Core MVC
- ASP.NET Core Web API

## Architecture

### ASP.NET Core MVC Assignment (N-tier)
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
        ├───css
        ├───js
        └───lib
```

### ToDo API Assignment (Clean Architecture)
```bash
ToDoApiAssignment
├───Core
│   ├───ToDoApiAssignment.Application
│   │   ├───DTOs
│   │   ├───Interfaces
│   │   ├───Mappings
│   │   └───Services
│   └───ToDoApiAssignment.Domain
│       ├───Entities
│       └───Interfaces
├───Infrastructure
│   ├───ToDoApiAssignment.Infrastructure
│   └───ToDoApiAssignment.Persistence
│       ├───Data
│       ├───Interfaces
│       └───Repositories
└───Presentation
    └───ToDoApiAssignment.Api
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

### Step 2: Navigate to the desired assignment
Depending on which assignment you want to run:
- For C# Fundamentals Assignment Day 1:
```sh
cd AssignmentDay1/AssignmentDay1
```
- For C# Fundamentals Assignment Day 2:
```sh
cd AssignmentDay2/AssignmentDay2
```
- For ASP.NET Core Fundamentals Middleware Assignment:
    - Ensure that you provide a valid endpoint to process HTTP requests and generate logs in logs.txt
    - Example: http://localhost:5110/Cars/FilterByModel?model=Mustang
```sh
cd MiddlewareAssignment/MiddlewareAssignment
```
- For ASP.NET Core MVC Assignment:
```sh
cd MvcAssignment/MvcAssignment.Web
```
- For ToDo API Assignment:
```sh
cd ToDoApiAssignment/Presentation/ToDoApiAssignment.Api
```

### Step 3: Run the application 
Inside the respective folder, execute:
```sh
dotnet run
```