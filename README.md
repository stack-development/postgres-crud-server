# ⚡️ Asynchronous PostgreSQL CRUD REST API Engine

A high-performance asynchronous REST API backend engineered with C# (.NET 8) and PostgreSQL. The system is architected utilizing Enterprise Design Patterns, clean data isolation layers, and containerized infrastructure.

## 🛠️ Tech Stack & Infrastructure

- **Backend Core:** Microsoft .NET 8.0 SDK (ASP.NET Core Web API)
- **Database Engine:** PostgreSQL (Relational DBMS)
- **Data Access Layer:** Entity Framework Core (Npgsql Provider)
- **API Documentation:** OpenAPI Specification / Swagger UI
- **Containerization:** Docker & Docker Compose (Multi-stage builds)

## 🏗️ Architectural Overview (Clean Architecture)

The application strictly follows Clean Architecture principles to ensure scalability, testability, and separation of concerns:

1. **Presentation Layer (Controllers):** Handles asynchronous HTTP routing, request validation, and standard HTTP response status codes (200, 201, 404, 500).
2. **Business Logic Layer (Services):** Isolated `ItemService` processing engine utilizing `async/await` patterns for non-blocking I/O operations.
3. **DTO Layer:** Strict security boundary. Specialized `CreateItemDto` and `UpdateItemDto` protect internal database models and prevent mass-assignment vulnerabilities.
4. **Data Access Layer:** Robust `AppDbContext` management with automated EF Core schema migrations on startup.

## 📋 REST API Endpoints

| Method | Endpoint | Payload | Description |
| :--- | :--- | :--- | :--- |
| **POST** | `/api/items` | `CreateItemDto` | Validates and creates a new record in PostgreSQL |
| **GET** | `/api/items` | None | Fetches a collection of items using non-blocking streams |
| **GET** | `/api/items/{id}` | URL Param | Queries a specific record by unique ID |
| **PUT** | `/api/items/{id}` | `UpdateItemDto` | Modifies existing data with concurrency state protection |
| **DELETE** | `/api/items/{id}` | URL Param | Safely removes target record from the database |

## 💻 Deployment & Quickstart

### Prerequisites
- Docker & Docker Compose installed on your host system.

### Step 1: Clone and Run via Docker Compose
The easiest way to spin up both the API engine and the PostgreSQL database in isolated networks:
```bash
docker compose up --build -d
```

### Step 2: Local Development Alternative
If you prefer running the application locally against a containerized database:

1. Start PostgreSQL:
   ```bash
   docker run --name local-postgres -e POSTGRES_PASSWORD=mysecretpassword -p 5432:5432 -d postgres
   ```
2. Apply migrations:
   ```bash
   dotnet ef database update
   ```
3. Run the WebAPI environment:
   ```bash
   dotnet run --configuration Release
   ```

Once initialized, navigate to: `http://localhost:5027/swagger/index.html` to access the OpenAPI interactive control panel.
