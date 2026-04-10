# ERP System

A full-stack, modular Enterprise Resource Planning (ERP) system built with .NET 10 and Next.js 15. Designed as a production-grade portfolio project demonstrating clean architecture, CQRS, domain-driven design, and modern DevOps practices.

## Tech Stack

### Backend

- .NET 10 / ASP.NET Core Web API
- PostgreSQL 16 + Entity Framework Core
- Redis (Caching)
- MediatR (CQRS)
- FluentValidation
- AutoMapper
- Serilog (Structured Logging)
- JWT Authentication + RBAC
- Docker + Docker Compose
- xUnit + Moq + FluentAssertions

### Frontend

- Next.js 15 (App Router)
- TypeScript
- Tailwind CSS + shadcn/ui
- Zustand (State Management)
- Axios

## Modules

| Module      | Description                              | Status         |
| ----------- | ---------------------------------------- | -------------- |
| HR          | Employee management, payroll, attendance | 🚧 In Progress |
| Finance     | Invoices, transactions, budgeting        | 📋 Planned     |
| Inventory   | Products, stock, warehouse               | 📋 Planned     |
| CRM         | Customers, leads, sales pipeline         | 📋 Planned     |
| Procurement | Purchase orders, suppliers               | 📋 Planned     |

## Project Structure

```txt

erp-system/
├── client/ # Next.js frontend
├── server/ # .NET backend
│ └── ERP/
│ ├── src/
│ │ ├── ERP.API
│ │ ├── ERP.Application
│ │ ├── ERP.Domain
│ │ └── ERP.Infrastructure
│ ├── tests/
│ │ └── ERP.UnitTests
│ └── docs/
├── docker/ # Docker Compose files
├── scripts/ # Utility scripts
└── .github/ # CI/CD workflows

```

## Getting Started

### Prerequisites

- .NET 10 SDK
- Node.js 20+
- Docker Desktop
- PostgreSQL 16 (or use Docker)

### 1. Clone the repo

```bash
git clone https://github.com/yourusername/erp-system.git
cd erp-system
```

### 2. Start infrastructure

```bash
docker compose -f docker/docker-compose.yml up -d
```

### 3. Run the backend

```bash
cd server/ERP
dotnet restore
dotnet run --project src/ERP.API
```

### 4. Run the frontend

```bash
cd client
pnpm install
pnpm dev
```

## API Documentation

Swagger UI available at: `https://localhost:5001/swagger`

## Documentation

- [Architecture](server/ERP/docs/architecture.md)
- [Database Schema](server/ERP/docs/db-schema.md)
- [API Contracts](server/ERP/docs/api-contracts.md)

## Git Workflow

- `main` → production only
- `develop` → integration branch
- `feature/*` → active development

## License

Apache License
