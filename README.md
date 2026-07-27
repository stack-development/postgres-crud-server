# ⚡️ Enterprise-Grade PostgreSQL CRUD REST API Engine

A high-performance, rock-solid asynchronous backend server engineered with **C# (.NET 8)** and **PostgreSQL**. This system is architected from the ground up utilizing enterprise-level design patterns, strict data isolation layers, and multi-stage cloud containerization.

---

## 🛠️ CORE TECH STACK & INFRASTRUCTURE
*   **Backend Core:** `Microsoft .NET 8.0 SDK` (Asynchronous C# / ASP.NET Core Web API)
*   **Database Engine:** `PostgreSQL` (Relational Database Management System)
*   **Object-Relational Mapping (ORM):** `Entity Framework Core` (Npgsql Provider)
*   **API Standardization:** `OpenAPI Specification` / `Swagger UI` (Swashbuckle)
*   **Deployment & Virtualization:** `Docker` (Multi-stage isolated environments)
*   **Operating System Environment:** `Arch Linux` (Development baseline)

---

## 🏗️ ADVANCED ARCHITECTURAL DESIGN (CLEAN CODE)

This engine avoids amateurish "monolithic spaghetti code" and is split into strict, isolated architectural layers to ensure maximum scalability and maintainability for corporate-level products:

### 1. Presentation Layer (API Controllers)
*   Handles secure incoming HTTP routing (`GET`, `POST`, `PUT`, `DELETE`).
*   Processes data validation and handles native standard HTTP Response status codes (`200 OK`, `201 Created`, `404 Not Found`, `500 Internal Error`).

### 2. Business Logic Layer (Service Pattern)
*   Isolated `ItemService` processing engine. All operations are completely asynchronous (`async/await`) to handle ultra-high concurrency and thousands of parallel connections without blocking threads.

### 3. Data Transfer Objects (DTO) Layer
*   **Strict Security Isolation:** External clients never interact directly with database entities. Specialized `CreateItemDto` and `UpdateItemDto` guard the database from unauthorized parameter modification and secure auto-incrementing Primary Keys (`Id`).

### 4. Data Access Layer (Infrastructure)
*   Robust `AppDbContext` management with integrated automatic schema migrations (`AUTO_MIGRATE`), ensuring zero-downtime microservice orchestration during automated live cluster updates.

---

## 📋 PRODUCTION REST API ENDPOINTS

| Method  | Endpoint | Payload | Description|
| :---    | :--- | :---   | :---            |
| `POST`  | `/items`      | `CreateItemDto` | Validates, serializes, and creates a record in PostgreSQL |
| `GET`   | `/items`      | *None* | Fetches a collection of items using non-blocking streams |
| `GET`   | `/items/{id}` | *URL Parameter* | Dynamically queries a single specific record by unique ID |
| `PUT`   | `/items/{id}` | `UpdateItemDto` | Modifies existing data context with state-concurrency protection |
| `DELETE`| `/items/{id}` | *URL Parameter* | Safely removes target record index from the relational state |

---

## 💻 DEPLOYMENT & DEV QUICKSTART

### Prerequisites
Ensure your local host or server has the **Docker Daemon** actively running.

### Step 1: Spin up Isolated Database Infrastructure
Launch a high-performance PostgreSQL instance inside an isolated container networking space:
```bash
docker run --name local-postgres -e POSTGRES_PASSWORD=mysecretpassword -p 5432:5432 -d postgres
```

### Step 2: Apply Advanced Database Migrations
Generate and execute physical database schema tables dynamically via EF Core CLI tools:
```bash
dotnet ef database update
```

### Step 3: Run the High-Performance Engine
Compile and launch the WebAPI environment locally in Release-optimized mode:
```bash
dotnet run
```
Once initialized, navigate your secure browser to: `http://localhost:5027/swagger/index.html` to instantly interact with the visual OpenAPI Control Panel.
