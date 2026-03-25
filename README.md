# 🚀 Orbitly

Orbitly is a fullstack social media project inspired by platforms like Instagram and Twitter.  
It focuses on building a modern feed system using clean architecture and scalable backend patterns.

---

## 🧠 Architecture

- Clean Architecture
- CQRS with MediatR
- Repository Pattern
- Entity Framework Core

---

## ⚙️ Backend (ASP.NET Core)

### Features
- Create posts
- Get paginated feed
- Random posts
- Feed based on user connections
- Validation pipeline

### Tech Stack
- ASP.NET Core
- MediatR
- Entity Framework Core
- PostgreSQL

---

## 💻 Frontend (React + Vite)

### Features
- Feed visualization
- API integration with Axios

### Tech Stack
- React
- Vite
- Axios

---

## 🔥 Current Status

- Backend running ✅
- Database connected ✅
- Feed working (recent + random) ✅
- React consuming API ✅
- Basic UI implemented ⚠️
- Authentication not implemented ❌

---

## 📂 Project Structure

```
Orbitly/
 ├── Orbitly.Api
 ├── Orbitly.Application
 ├── Orbitly.Domain
 ├── Orbitly.Infrastructure
 └── orbitly-web (React)
```

---

## ▶️ How to Run

### Backend

```bash
dotnet run --project Orbitly.Api
```

### Frontend

```bash
cd orbitly-web
npm install
npm run dev
```

---

## 🌐 Ports

- Backend: http://localhost:5196
- Frontend: http://localhost:5173

---

## 🚧 Next Steps

- Improve UI (PostCard component)
- Create post feature (frontend form)
- Implement authentication
- Improve constellation feed logic

---

## 📌 Notes

This project is being developed as a learning and portfolio project, focusing on:
- Backend architecture
- API design
- Integration with frontend
- Real-world system simulation

---

## 👨‍💻 Author

Developed as part of a backend learning journey into modern systems and AI-ready architectures.
