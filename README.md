# TaskManager

A personal task management web application built with **ASP.NET Core MVC** and **Entity Framework Core**.

---

## Tech Stack

- ASP.NET Core 8.0
- Entity Framework Core 8.0 with SQLite
- ASP.NET Identity — authentication
- Razor Views + Bootstrap 5
- Developed with JetBrains Rider on Linux

---

## Features

- Create, edit and delete tasks
- Set priority (Low / Normal / High) and deadline
- Mark tasks as completed
- User authentication — each user sees only their own tasks
- Dark mode UI
- Filter by priority / status

---

## Getting Started

**Prerequisites:** .NET 8.0 SDK

```bash
git clone https://github.com/papura-octavian/TaskManager.git
cd TaskManager/TaskManager
dotnet restore
dotnet ef database update
dotnet run
```

App runs at `http://localhost:5055`

---

## Planned Features
- Deadline notifications

---

## Author

Built as a learning project for ASP.NET Core MVC.
