# 🎮 Video Game Catalog Web API (.NET 8/9 & MongoDB)

A robust, modern RESTful Web API built with **.NET** and **MongoDB**, designed for managing a video game catalog. This project features full CRUD operations, advanced aggregation pipelines using MongoDB Builders, and containerized deployment with Docker.

---

## 🚀 Features

- **Full CRUD Operations**: Create, Read, Update, and Delete video game records.
- **Advanced Aggregation**: Custom endpoint calculating statistics per genre (total games, average price, and average rating) using MongoDB aggregation pipelines.
- **NoSQL Persistence**: Leverages MongoDB document storage (`BSON`/`JSON`-like structure) for flexible schema management.
- **Environment Configuration**: Uses the Options Pattern (`IOptions<T>`) for clean, secure configuration management.
- **Interactive Documentation**: Fully integrated with Swagger/OpenAPI for easy endpoint testing.

---

## 🛠️ Tech Stack & Tools

- **Backend**: .NET 8/9 Web API (C#)
- **Database**: MongoDB (Official `MongoDB.Driver`)
- **Containerization**: Docker & Docker Compose
- **Documentation**: Swagger / OpenAPI
- **Development Tools**: Visual Studio / VS Code, Git

---

## 📋 Project Architecture

```text
MongoCrudApi/
│
├── Controllers/
│   └── GamesController.cs    # REST API Endpoints
├── Data/
│   └── MongoDbContext.cs     # MongoDB Client & Connection Context
├── Models/
│   ├── Game.cs               # Game Entity Model
│   └── GameStoreDatabaseSettings.cs # Configuration Model
├── Services/
│   └── GameService.cs        # Business Logic, CRUD & Aggregation Queries
├── appsettings.json          # Default configuration
├── appsettings.Development.json # Local development settings
└── Program.cs                # DI Container & Middleware setup