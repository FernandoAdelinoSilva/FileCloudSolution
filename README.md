# ☁️ Cloud Storage System

A simple in-memory cloud storage system that maps files to their metadata (name, size, etc.).

---

## 📌 Levels of Functionality

- **Level 1**
  - Add new files - endpoint AddFile ✅
  - Retrieve files - endpoint GetAllFiles ✅
  - Delete files - endpoint DeleteFile ✅

- **Level 2**
  - Display the largest file - endpoint GetLargestFile ✅

- **Level 3**
  - Add users with limited capacity ✅
  - Show All files for each user ✅

---

## 🚀 Features

- **C# Backend API**
  - Endpoints:
    - Get All Files
    - Get File By Name
    - Get Largest File
    - Add File (with validation and exception if file already exists)
    - Remove File
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