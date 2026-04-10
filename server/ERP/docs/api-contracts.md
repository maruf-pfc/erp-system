# ERP System — API Contracts

## Base URL

- Development: https://localhost:5001
- Staging: https://staging-api.erp.com

## Authentication

All endpoints require JWT Bearer token except /auth/\*

Authorization: Bearer <token>

## Standard Response Wrapper

Every response follows this shape:

### Success

```json
{
  "succeeded": true,
  "data": {},
  "message": "Employee created successfully"
}
```

### Paginated

```json
{
  "succeeded": true,
  "data": [],
  "pageNumber": 1,
  "pageSize": 10,
  "totalCount": 100,
  "totalPages": 10
}
```

### Error

```json
{
  "succeeded": false,
  "message": "Validation failed",
  "errors": ["Email is required", "Salary must be positive"]
}
```

---

## HR Module

### Employees

| Method | Endpoint            | Description        | Auth           |
| ------ | ------------------- | ------------------ | -------------- |
| GET    | /api/employees      | List all employees | Admin, Manager |
| GET    | /api/employees/{id} | Get employee by ID | Admin, Manager |
| POST   | /api/employees      | Create employee    | Admin          |
| PUT    | /api/employees/{id} | Update employee    | Admin          |
| DELETE | /api/employees/{id} | Soft delete        | Admin          |

#### POST /api/employees

```json
// Request
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@company.com",
  "phone": "+8801700000000",
  "department": "Engineering",
  "position": "Senior Developer",
  "salary": 80000,
  "joinDate": "2026-01-01"
}

// Response 201
{
  "succeeded": true,
  "data": {
    "id": "a3f8b2c1-...",
    "firstName": "John",
    "lastName": "Doe",
    "email": "john@company.com",
    "status": "Active"
  },
  "message": "Employee created successfully"
}
```

---

## Finance Module

### Invoices

| Method | Endpoint                  | Description    |
| ------ | ------------------------- | -------------- |
| GET    | /api/invoices             | List invoices  |
| GET    | /api/invoices/{id}        | Get invoice    |
| POST   | /api/invoices             | Create invoice |
| PUT    | /api/invoices/{id}/status | Update status  |
| DELETE | /api/invoices/{id}        | Soft delete    |

---

## Inventory Module

### Products

| Method | Endpoint                | Description     |
| ------ | ----------------------- | --------------- |
| GET    | /api/products           | List products   |
| GET    | /api/products/{id}      | Get product     |
| GET    | /api/products/low-stock | Low stock alert |
| POST   | /api/products           | Create product  |
| PUT    | /api/products/{id}      | Update product  |
| DELETE | /api/products/{id}      | Soft delete     |

---

## CRM Module

### Customers

| Method | Endpoint                     | Description       |
| ------ | ---------------------------- | ----------------- |
| GET    | /api/customers               | List customers    |
| GET    | /api/customers/{id}          | Get customer      |
| GET    | /api/customers/{id}/invoices | Customer invoices |
| POST   | /api/customers               | Create customer   |
| PUT    | /api/customers/{id}          | Update customer   |

---

## Procurement Module

### Purchase Orders

| Method | Endpoint                          | Description |
| ------ | --------------------------------- | ----------- |
| GET    | /api/purchase-orders              | List POs    |
| GET    | /api/purchase-orders/{id}         | Get PO      |
| POST   | /api/purchase-orders              | Create PO   |
| PUT    | /api/purchase-orders/{id}/approve | Approve PO  |
| PUT    | /api/purchase-orders/{id}/cancel  | Cancel PO   |

---

## Auth Module

| Method | Endpoint          | Description      |
| ------ | ----------------- | ---------------- |
| POST   | /api/auth/login   | Get JWT token    |
| POST   | /api/auth/refresh | Refresh token    |
| POST   | /api/auth/logout  | Invalidate token |

## Error Codes

| Code | Meaning                |
| ---- | ---------------------- |
| 400  | Validation error       |
| 401  | Unauthorized           |
| 403  | Forbidden (wrong role) |
| 404  | Resource not found     |
| 409  | Conflict (duplicate)   |
| 500  | Server error           |
