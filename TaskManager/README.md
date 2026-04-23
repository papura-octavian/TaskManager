# 📋 TaskManager

A personal task management web application built with **ASP.NET Core MVC** and **Entity Framework Core**.

---

## Tech Stack

- **ASP.NET Core 8.0** — web framework
- **MVC (Model-View-Controller)** — application architecture
- **Entity Framework Core 8.0** — database ORM
- **SQLite** — local database
- **Razor Views** — UI template engine
- **Bootstrap 5** — UI styling
- **JetBrains Rider** — IDE (developed on Linux)

---

## Features

- ✅ Create new tasks with title, description, priority and deadline
- ✅ View all tasks in a list
- ✅ Delete tasks
- ✅ Task statuses: In Progress / Done
- ✅ Priority levels: Low / Normal / High
- ✅ Data persistence with SQLite

---

## 📁 Project Structure

```
TaskManager/
├── Controllers/
│   ├── HomeController.cs       # Home page logic
│   └── TasksController.cs      # CRUD logic for tasks
├── Models/
│   ├── TaskItem.cs             # Task model
│   └── AppDbContext.cs         # Database context
├── Views/
│   ├── Shared/
│   │   └── _Layout.cshtml      # Shared layout
│   ├── Home/
│   │   └── Index.cshtml        # Home page
│   └── Tasks/
│       ├── Index.cshtml        # Task list
│       └── Create.cshtml       # Create task form
├── Migrations/                 # Entity Framework migrations
├── wwwroot/                    # Static files (CSS, JS)
├── appsettings.json            # App configuration
├── Program.cs                  # Application entry point
└── taskmanager.db              # SQLite database file
```

---

## ⚙️ Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

```bash
# Clone the repository
git clone https://github.com/papura-octavian/TaskManager.git
cd TaskManager/TaskManager

# Restore dependencies
dotnet restore

# Apply database migrations
dotnet ef database update

# Run the application
dotnet run
```
---

## Planned Features

- [ ] Edit existing tasks
- [ ] Mark tasks as completed
- [ ] User authentication (ASP.NET Identity)
- [ ] Filter by priority / status
- [ ] Deadline notifications

---

## Author

Built as a learning project for ASP.NET Core MVC.
