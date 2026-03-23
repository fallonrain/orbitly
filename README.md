# 🌌 Orbitly

A slow social network built to encourage thoughtful conversations instead of dopamine-driven engagement.

---

## ✨ About the Project

Orbitly is a backend-first project designed to explore modern backend architecture using .NET.

The platform follows a **digital minimalism philosophy**, where users interact through meaningful text-based posts instead of likes, followers, or infinite scrolling.

Each user is represented as a **star**, and interactions form a **cosmic network**.

---

## 🧠 Core Concepts

- Users are **stars**
- Posts are **light emissions**
- Replies are **orbits**
- Connections form **constellations**
- Feed is the **Night Sky**

---

## 🚀 Features Implemented

- ✅ Clean Architecture (Domain, Application, Infrastructure, API)
- ✅ MediatR (CQRS pattern)
- ✅ Entity Framework Core
- ✅ PostgreSQL (Docker)
- ✅ Repository Pattern
- ✅ Post creation endpoint
- ✅ Business rule: **1 post per day per user**
- ✅ Validation at application layer
- ✅ Persistence with EF Core
- ✅ SQL logging for debugging

---

## 🏗️ Architecture

```
API → Application → Domain
           ↑
     Infrastructure
```

- **Domain** → Business rules and entities  
- **Application** → Use cases and commands  
- **Infrastructure** → Database and external services  
- **API** → HTTP layer  

---

## 🛠️ Tech Stack

- .NET 8
- ASP.NET Core Web API
- MediatR
- Entity Framework Core
- PostgreSQL
- Docker

---

## ⚙️ Running the Project

### 1. Clone the repository

```bash
git clone https://github.com/fallonrain/orbitly.git
cd orbitly
```

---

### 2. Run PostgreSQL with Docker

```bash
docker run -d --name orbitly-postgres -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=orbitly -p 5432:5432 postgres:15
```

---

### 3. Apply migrations

```bash
dotnet ef database update --project Orbitly.Infrastructure --startup-project Orbitly.Api
```

---

### 4. Run the API

```bash
dotnet run --project Orbitly.Api
```

---

### 5. Access Swagger

http://localhost:5196/swagger

---

## 🧪 Example Request

POST `/api/posts`

```json
{
  "userId": "11111111-1111-1111-1111-111111111111",
  "content": "My first post in the galaxy 🌌"
}
```

---

## 🚫 Business Rules

- A user can only create **one post per day**
- Posts must have:
  - max 500 characters
  - non-empty content

---

## 📈 Future Improvements

- Global error handling (ProblemDetails)
- Authentication (JWT)
- User management
- Feed (Night Sky)
- Replies (Orbits)
- Redis caching
- Supernova detection (high-engagement posts)

---

## 🎯 Goal

This project aims to simulate a **real-world backend system**, focusing on:

- scalability
- maintainability
- clean architecture
- real business rules

---

## 👩‍💻 Author

Developed by Thiago Fernandes 

