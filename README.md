# SATS — Student Attendance Tracking System

A web-based system for recording student attendance via QR codes, built with a Clean Architecture approach on ASP.NET Core.

## Overview

SATS lets instructors open a time-boxed attendance session for a course session, generate a QR code for it, and have students scan it to record their attendance. Every meaningful action in the system (attendance scans, record changes, etc.) is captured in an audit trail for accountability.

## Architecture

Domain          → Entities and repository interfaces. No dependencies on any other layer.
Infrastructure  → EF Core DbContext, repository implementations, migrations.
Application     → DTOs, service interfaces, service implementations (business rules), AutoMapper profiles.
SATS.API        → ASP.NET Core Web API controllers (presentation layer), Swagger, exception middleware.

The solution is split into four projects, each with a single responsibility, following Clean Architecture:



Dependencies only point inward: `API → Application → Domain`, with `Infrastructure` implementing the interfaces defined in `Domain`. This keeps business rules independent of EF Core and the web framework, and makes each layer independently testable.

## Tech Stack

- **Framework:** ASP.NET Core Web API (.NET 5.0)
- **ORM:** Entity Framework Core (Code-First, with Migrations)
- **Database:** SQL Server
- **Object Mapping:** AutoMapper
- **API Docs:** Swagger / Swashbuckle

## Domain Model

| Entity | Purpose |
|---|---|
| **User** | Unified table for both students and instructors, distinguished by a `Role` field. |
| **Course** | A course, owned by one instructor (`User`). |
| **Enrollment** | Links a student (`User`) to a `Course`. |
| **AttendanceSession** | A single class meeting that accepts attendance, identified by a `QRCodeToken`, with a `Status` (Open/Closed) and active window. |
| **AttendanceRecord** | One student's scan against an `AttendanceSession`. Unique per (student, session) pair. |
| **AuditLog** | An audit trail entry: who (`User`) did what (`Action`), optionally tied to an `AttendanceRecord`, with a `Timestamp`. |

Key relationship rules (enforced via EF Core Fluent API):
- Deleting a `User` cascades to their `AuditLogs`, but an `AttendanceRecord` can be deleted **without** deleting its associated audit logs (`Restrict`) — audit history is preserved even if the underlying record is removed.
- An `AttendanceRecord` is unique per `(StudentId, SessionId)` — a student can't be recorded twice for the same session.

## Project Structure
Domain/
  Entities/         User, Course, Enrollment, AttendanceSession, AttendanceRecord, AuditLog
  IRepository/      IUserRepository, ICourseRepository, IEnrollmentRepository,
                     IAttendanceSessionRepository, IAttendanceRecordRepository, IAuditLogRepository
  Common/           Shared domain constants (e.g. session status values)

Infrastructure/
  Data/             AppDbContext (DbSets + Fluent API model configuration)
  Repository/       EF Core implementations of the Domain repository interfaces
  Migrations/       EF Core migrations

Application/
  DTOs/             Data transfer objects exposed by the API
  IService/         Service interfaces (business-facing contracts)
  ServiceImpl/      Service implementations — validation and business rules live here
  Common/           AutoMapper profile, custom exceptions, business rule constants

SATS.API/
  Controllers/      REST controllers (Users, Courses, Enrollments, AttendanceSessions,
                     AttendanceRecords, AuditLogs) + shared BaseController
  Middleware/        Global exception-handling middleware
  Program.cs          DI registration, DB migration on startup, Swagger setup

## Getting Started

### Prerequisites
- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- SQL Server (local or containerized)

### Setup
1. Clone the repository.
2. Update the connection string in `SATS.API/appsettings.json` under `ConnectionStrings:DefaultConnection` to point to your SQL Server instance.
3. Run the API:
```bash
   cd SATS.API
   dotnet run
```
   Pending EF Core migrations are applied automatically on startup (`db.Database.Migrate()` in `Program.cs`), so no manual `dotnet ef database update` step is required.
4. Open the Swagger UI at `https://localhost:<port>/swagger` to explore and test the API.

## API Endpoints (summary)

| Resource | Endpoints |
|---|---|
| Users | `GET /api/users`, `GET /api/users?email=`, `GET /api/users/{id}`, `POST /api/users`, `PUT /api/users/{id}` |
| Courses | `GET /api/courses`, `GET /api/courses/{id}`, `POST /api/courses`, `PUT /api/courses/{id}` |
| Enrollments | `GET /api/enrollments`, `POST /api/enrollments` |
| Attendance Sessions | `GET /api/attendancesessions`, `POST /api/attendancesessions` |
| Attendance Records | `GET /api/attendancerecords`, `POST /api/attendancerecords` |
| Audit Logs | `GET /api/auditlogs?userId=` or `?recordId=`, `POST /api/auditlogs` |

Full request/response schemas are available via Swagger once the API is running.

## Error Handling

All controllers inherit from a shared `BaseController` that standardizes success/error responses. A global `ExceptionMiddleware` catches unhandled exceptions so the API always returns a consistent JSON error shape instead of a raw stack trace.

## Team

Built for a Software Engineering course project.

- Emad Al-Soufi
- Amr Khaled
- Mazen Nussari
- Albaraa Al-sormi

## License

Academic project — for coursework purposes.
