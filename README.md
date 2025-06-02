# EF Core MVC Training Project

This project is a simple ASP.NET Core MVC web application that demonstrates working with **Entity Framework Core (Code First)** and full **CRUD operations**.

## What’s inside?

The project includes **5 Models** with one-to-many relationships:

- `Department`  
- `Instructor`  
- `Course`  
- `Trainee`  
- `CrseResult`

Each model is related using proper navigation properties and foreign keys.  

## Features

- ASP.NET Core MVC structure
- Code First with Migrations
- One-to-Many Relationships
- Views using Razor
- Relational data display (e.g. Instructors)
- Database generated via Migrations
- Clean and readable UI

## Technologies

- ASP.NET Core MVC  
- C#  
- Entity Framework Core  
- SQL Server  
- Visual Studio 2022

## UI Sample

All views are styled using simple CSS and Razor Pages for listing and viewing entity details.

## How to Run

1. Clone the repo
2. Open the solution in Visual Studio
3. Update the connection string in `AppDbContext.cs`
4. Run the following commands:
   Add-Migration Initial
   Update-Database
5. Press `Ctrl + F5` to launch the app

---

Developed by Somaya 

