# EF Core MVC Training Project

This project is a clean and structured ASP.NET Core MVC web application that demonstrates practical usage of Entity Framework Core (Code First) along with complete CRUD operations, modern design principles, and MVC best practices.

## Domain Models

The project includes 5 core Models with One-to-Many relationships:

- Department
- Instructor
- Course
- Trainee
- CrsResult

Relationships are set up using navigation properties and proper foreign keys. 

## Features

- ASP.NET Core MVC structure
- Code First with Migrations
- One-to-Many Relationships
- Views using Razor
- Relational data display (e.g. Instructors)
- Database generated via Migrations
- Clean and readable UI

## Updated Features

- ASP.NET Core MVC architecture
- Entity Framework Core (Code First) with Migrations
- Full CRUD operations with validation
- Pagination implemented using LINQ
- ViewModels to separate form data from domain models
- Tag Helpers for form generation
- State Management via Cookies and Sessions
- Custom Validation Attributes (e.g., Unique Course Name per Department)
- Remote Validation using AJAX for live server-side checks
- Details view with success/failure status based on grades
- Clean separation of concerns using Repository Pattern & Interfaces
- Identity & Authorization system implemented (Admin, Roles, Login, Logout)


## Design Patterns & Principles Used

- Repository Pattern  
  Abstracts data access logic and separates it from controllers.

- Dependency Injection  
  All repositories are injected into controllers using built-in DI.

- Separation of Concerns  
  Controllers focus only on control flow; database logic is moved to repositories.

- DRY Principle  
  Reusable generic repository pattern for common operations.

## Technologies

- ASP.NET Core MVC (.NET 6+)
- C#
- Entity Framework Core
- SQL Server
- Razor View Engine
- Visual Studio 2022
- ASP.NET Core Identity
- Authentication / Authorization

## How to Run

1. Clone the repo
2. Open the solution in Visual Studio
3. Update the connection string in `Context.cs`
4. Run the following commands:
   Add-Migration Initial
   Update-Database
5. Press `Ctrl + F5` to launch the app

---

## UI Sample

### 🏠 Courses Index Test Page
![Courses Index](screenshots/courses-index.png)

## Developed By

Developed with ❤ by Somaya 
.NET Developer in training, focusing on backend development and clean architecture.


