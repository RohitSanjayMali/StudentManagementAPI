# Student Management API

A RESTful API built with ASP.NET Core 9.0 for managing student records.

## Features
- JWT Authentication
- CRUD operations for Students
- Entity Framework Core with SQL Server
- Serilog Logging
- Swagger UI

## Tech Stack
- ASP.NET Core 9.0
- Entity Framework Core 9.0
- SQL Server / LocalDB
- JWT Bearer Authentication
- Serilog
- Swagger / Swashbuckle

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server or LocalDB

### Setup

1. Clone the repository
```
git clone https://github.com/your-username/StudentManagementAPI.git
```

2. Update connection string in `appsettings.json`
```json
"ConnectionStrings": {
  "DefaultConnection": "your-connection-string"
}
```

3. Run migrations
```
dotnet ef database update
```

4. Run the project
```
dotnet run
```

5. Open Swagger UI
```
https://localhost:7020/swagger
```

## API Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | /api/Auth/login | Get JWT token | No |
| GET | /api/Student | Get all students | Yes |
| GET | /api/Student/{id} | Get student by ID | Yes |
| POST | /api/Student | Add new student | Yes |
| PUT | /api/Student/{id} | Update student | Yes |
| DELETE | /api/Student/{id} | Delete student | Yes |

## Authentication

First call the login endpoint to get a JWT token:

```json
POST /api/Auth/login
{
  "username": "admin",
  "password": "password"
}
```

Then use the token in the Authorization header:
```
Bearer <your-token-here>
```

## Default Login Credentials
- **Username:** `admin`
- **Password:** `password`

> ⚠️ Change these credentials before deploying to production.
