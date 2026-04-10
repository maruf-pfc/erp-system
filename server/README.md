# ERP System — Backend

ASP.NET Core 10 Web API following Clean Architecture, CQRS, and Repository patterns.

## Architecture

```txt

ERP.API → HTTP layer (Controllers, Middleware, Filters)
ERP.Application → Business logic (CQRS, Validation, Mapping)
ERP.Domain → Core entities, enums, exceptions (no dependencies)
ERP.Infrastructure → EF Core, Repositories, Services, Caching

```

### Dependency Rule

```txt

Domain ← Application ← Infrastructure
↑
API

```

Inner layers never reference outer layers.

## Prerequisites

- .NET 10 SDK
- Docker Desktop
- dotnet-ef tool

```bash
dotnet tool install --global dotnet-ef
```

## Setup

### 1. Start PostgreSQL + Redis

```bash
docker compose -f ../../docker/docker-compose.yml up -d
```

### 2. Restore & Build

```bash
dotnet restore
dotnet build
```

### 3. Apply Migrations

```bash
cd src/ERP.API

dotnet ef migrations add InitialCreate \
  --project ../ERP.Infrastructure \
  --startup-project . \
  --output-dir Persistence/Migrations

dotnet ef database update \
  --project ../ERP.Infrastructure \
  --startup-project .
```

### 4. Run API

```bash
dotnet run --project src/ERP.API
```

API runs at: `https://localhost:5001`
Swagger UI: `https://localhost:5001/swagger`

## Environment Variables

Configure in `src/ERP.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=erp_db;Username=erp_user;Password=erp_pass"
  },
  "JwtSettings": {
    "Secret": "your-secret-key",
    "ExpiryMinutes": 60,
    "Issuer": "erp-api",
    "Audience": "erp-client"
  }
}
```

## Running Tests

```bash
dotnet test
```

## Key Patterns

| Pattern                   | Purpose                                         |
| ------------------------- | ----------------------------------------------- |
| Clean Architecture        | Separation of concerns, testability             |
| CQRS + MediatR            | Separate read/write operations                  |
| Repository + UoW          | Abstracts DB access, transaction management     |
| Soft Delete               | Data never physically removed                   |
| Audit Trail               | Auto-tracks who created/updated every record    |
| Global Exception Handling | Consistent error responses                      |
| FluentValidation          | Clean validation pipeline via MediatR behaviors |

## Project Docs

- [Architecture](docs/architecture.md)
- [Database Schema](docs/db-schema.md)
- [API Contracts](docs/api-contracts.md)

## Adding a New Module

1. Add entity in `ERP.Domain/Entities/<Module>/`
2. Add enum in `ERP.Domain/Enums/`
3. Add EF config in `ERP.Infrastructure/Persistence/Configurations/`
4. Add Commands/Queries/DTOs in `ERP.Application/Features/<Module>/`
5. Add Controller in `ERP.API/Controllers/`
6. Run migration
