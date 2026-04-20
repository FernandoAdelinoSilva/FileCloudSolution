# ☁️ Cloud Storage System

A simple in-memory cloud storage system that maps files to their metadata (name, size, etc.).

---

## 📌 Levels of Functionality

- **Level 1**
  - Add new files
  - Retrieve files
  - Delete files

- **Level 2**
  - Display the largest file

- **Level 3**
  - Add users with limited capacity
  - Merge two users

- **Level 4**
  - Backup and restore user files

---

## 🚀 Features

- **C# Backend API**
  - Endpoints:
    - Get All Files
    - Get File By Name
    - Add File (with validation and exception if file already exists)
  - Singleton repository for files
- **Unit Tests**
  - Validate core operations
- **CI/CD**
  - Build solution
  - Run unit tests with GitHub Actions

---

## 🛠️ Tech Stack

- .NET 8
- ASP.NET Core Web API
- xUnit + Moq (unit testing)
- GitHub Actions (CI/CD)

---

## ▶️ How to Run

```bash
# Restore dependencies
dotnet restore

# Build solution
dotnet build

# Run unit tests
dotnet test