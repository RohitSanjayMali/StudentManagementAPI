# 🎓 Student Management API

A RESTful API built with **ASP.NET Core 9** for managing student records with JWT authentication, Entity Framework Core, and Serilog logging.

---

## 🚀 Tech Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core 9 | Web Framework |
| Entity Framework Core 9 | ORM / Database |
| SQL Server (LocalDB) | Database |
| JWT Bearer Authentication | Security |
| Serilog | Logging |
| Swagger / OpenAPI | API Documentation |

---

## 📁 Project Structure

```
StudentManagementAPI/
├── Controllers/
│   ├── AuthController.cs       # Login & JWT token generation
│   └── StudentController.cs    # Student CRUD operations
├── Data/
│   └── AppDbContext.cs         # EF Core DB Context
├── Middleware/
│   └── ExceptionMiddleware.cs  # Global error handling
├── Migrations/                 # EF Core Migrations
├── Models/
│   ├── Student.cs              # Student entity
│   └── LoginDto.cs             # Login request model
├── Repositories/
│   ├── IStudentRepository.cs   # Repository interface
│   └── StudentRepository.cs    # Repository implementation
├── Services/
│   ├── IStudentService.cs      # Service interface
│   └── StudentService.cs       # Business logic
├── appsettings.json            # Configuration
└── Program.cs                  # App entry point
```

---

## ⚙️ Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server or LocalDB
- Visual Studio 2022

### 1. Clone the repository
```bash
git clone https://github.com/RohitSanjayMali/StudentManagementAPI.git
cd StudentManagementAPI
```

### 2. Configure `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=StudentManagementDB;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "YourSuperSecretKeyHere"
  }
}
```

### 3. Apply Database Migrations
```bash
dotnet ef database update
```

### 4. Run the API
```bash
dotnet run
```

Swagger UI: `https://localhost:7020/swagger`

---

## 🔐 Authentication

This API uses **JWT Bearer Token** authentication.

### Login
```http
POST /api/Auth/login
Content-Type: application/json

{
  "username": "admin",
  "password": "password"
}
```

### Response
```json
{
  "message": "Login successful",
  "token": "eyJhbGci..."
}
```

Use this token in the **Authorization** header:
```
Bearer <your_token_here>
```

---

## 📌 API Endpoints

### Auth
| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/Auth/login` | Get JWT token | ❌ |

### Students
| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| GET | `/api/Student` | Get all students | ✅ |
| GET | `/api/Student/{id}` | Get student by ID | ✅ |
| POST | `/api/Student` | Add new student | ✅ |
| PUT | `/api/Student/{id}` | Update student | ✅ |
| DELETE | `/api/Student/{id}` | Delete student | ✅ |

---

## 📝 Sample Request

### Add Student
```http
POST /api/Student
Authorization: Bearer <token>
Content-Type: application/json

{
  "name": "Rahul Sharma",
  "email": "rahul@gmail.com",
  "age": 20,
  "course": "Computer Science"
}
```

### Response
```json
{
  "message": "Student added successfully",
  "data": {
    "id": 1,
    "name": "Rahul Sharma",
    "email": "rahul@gmail.com",
    "age": 20,
    "course": "Computer Science",
    "createdDate": "2026-05-09T00:00:00"
  }
}
```

---

## 🏗️ Architecture

This project follows a **layered architecture**:

```
Controller → Service → Repository → Database
```

- **Controller** — Handles HTTP requests and responses
- **Service** — Business logic layer
- **Repository** — Data access layer
- **Middleware** — Global exception handling

---

## 👨‍💻 Author

**Rohit Sanjay Mali**  
[GitHub](https://github.com/RohitSanjayMali)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
