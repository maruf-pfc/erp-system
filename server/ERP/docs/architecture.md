# ERP System — Architecture Documentation

## Overview

A modular, clean-architecture ERP system built with .NET 10, PostgreSQL, and Redis.

## Architecture Pattern: Clean Architecture

```txt
ERP.API → ERP.Application → ERP.Domain
↑
ERP.Infrastructure
```

### Layer Responsibilities

| Layer          | Project            | Responsibility                  |
| -------------- | ------------------ | ------------------------------- |
| Presentation   | ERP.API            | HTTP, Controllers, Middleware   |
| Business Logic | ERP.Application    | CQRS, Validation, Mapping       |
| Core           | ERP.Domain         | Entities, Enums, Events         |
| Data           | ERP.Infrastructure | EF Core, Repositories, Services |

## Patterns Used

### 1. CQRS (Command Query Responsibility Segregation)

- Commands → write operations (Create, Update, Delete)
- Queries → read operations (Get, List)
- Implemented via MediatR

### 2. Repository + Unit of Work

- GenericRepository<T> → reusable CRUD
- UnitOfWork → transaction management
- Prevents direct DbContext access from Application layer

### 3. Soft Delete

- IsDeleted flag on AuditableEntity
- HasQueryFilter in EF config auto-excludes deleted records
- Data never physically removed

### 4. Audit Trail

- CreatedAt, UpdatedAt, CreatedBy, UpdatedBy
- Auto-set in AppDbContext.SaveChangesAsync override

## Request Flow

### HTTP Request

- Middleware (Auth, Logging, Exception)
- Controller (thin — just sends to MediatR)
- MediatR Pipeline Behavior (Validation → Logging)
- Command/Query Handler
- Repository via UnitOfWork
- AppDbContext
- PostgreSQL
- Response wrapped in ApiResponse<T>

## Security

- JWT Bearer Authentication
- Role-Based Access Control (RBAC)
- 6 roles: SuperAdmin, Admin, Manager, Staff, Viewer, External

## Caching Strategy

- Redis for frequently read data
- Cache-aside pattern
- TTL per data type

## Modules

| Module      | Status      |
| ----------- | ----------- |
| HR          | In Progress |
| Finance     | Planned     |
| Inventory   | Planned     |
| CRM         | Planned     |
| Procurement | Planned     |
