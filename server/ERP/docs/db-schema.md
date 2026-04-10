# ERP System — Database Schema

## Connection

- Engine: PostgreSQL 16
- Database: erp_db
- Host: localhost:5432

## Base Columns (Every Table)

| Column    | Type       | Description                     |
| --------- | ---------- | ------------------------------- |
| Id        | UUID       | Primary key, auto-generated     |
| CreatedAt | TIMESTAMP  | Auto-set on insert              |
| UpdatedAt | TIMESTAMP? | Auto-set on update              |
| CreatedBy | VARCHAR    | User who created                |
| UpdatedBy | VARCHAR?   | User who last updated           |
| IsDeleted | BOOLEAN    | Soft delete flag, default false |

---

## HR Module

### Employees

| Column         | Type          | Constraints                                   |
| -------------- | ------------- | --------------------------------------------- |
| Id             | UUID          | PK                                            |
| FirstName      | VARCHAR(100)  | NOT NULL                                      |
| LastName       | VARCHAR(100)  | NOT NULL                                      |
| Email          | VARCHAR(200)  | NOT NULL, UNIQUE                              |
| Phone          | VARCHAR(50)   |                                               |
| Department     | VARCHAR(100)  |                                               |
| Position       | VARCHAR(100)  |                                               |
| Salary         | DECIMAL(18,2) |                                               |
| JoinDate       | TIMESTAMP     |                                               |
| Status         | INT           | 1=Active, 2=Inactive, 3=OnLeave, 4=Terminated |
| + Base Columns |               |                                               |

---

## Finance Module

### Invoices

| Column         | Type          | Constraints                                     |
| -------------- | ------------- | ----------------------------------------------- |
| Id             | UUID          | PK                                              |
| InvoiceNumber  | VARCHAR       | NOT NULL                                        |
| CustomerId     | UUID          | FK → Customers                                  |
| IssuedDate     | TIMESTAMP     |                                                 |
| DueDate        | TIMESTAMP     |                                                 |
| TotalAmount    | DECIMAL(18,2) |                                                 |
| PaidAmount     | DECIMAL(18,2) |                                                 |
| Status         | INT           | 1=Draft, 2=Sent, 3=Paid, 4=Overdue, 5=Cancelled |
| + Base Columns |               |                                                 |

---

## Inventory Module

### Products

| Column         | Type          | Constraints      |
| -------------- | ------------- | ---------------- |
| Id             | UUID          | PK               |
| Name           | VARCHAR(200)  | NOT NULL         |
| SKU            | VARCHAR(100)  | NOT NULL, UNIQUE |
| Description    | TEXT          |                  |
| UnitPrice      | DECIMAL(18,2) |                  |
| StockQuantity  | INT           |                  |
| ReorderLevel   | INT           |                  |
| + Base Columns |               |                  |

---

## CRM Module

### Customers

| Column         | Type         | Constraints |
| -------------- | ------------ | ----------- |
| Id             | UUID         | PK          |
| FullName       | VARCHAR(200) | NOT NULL    |
| Email          | VARCHAR(200) | NOT NULL    |
| Phone          | VARCHAR(50)  |             |
| Company        | VARCHAR(200) |             |
| Address        | TEXT         |             |
| + Base Columns |              |             |

---

## Procurement Module

### PurchaseOrders

| Column           | Type          | Constraints                                    |
| ---------------- | ------------- | ---------------------------------------------- |
| Id               | UUID          | PK                                             |
| PONumber         | VARCHAR       | NOT NULL                                       |
| SupplierName     | VARCHAR(200)  |                                                |
| OrderDate        | TIMESTAMP     |                                                |
| ExpectedDelivery | TIMESTAMP     |                                                |
| TotalAmount      | DECIMAL(18,2) |                                                |
| Status           | INT           | 1=Pending, 2=Approved, 3=Received, 4=Cancelled |
| + Base Columns   |               |                                                |

## Migrations

| Migration     | Date       | Description     |
| ------------- | ---------- | --------------- |
| InitialCreate | 2026-04-10 | All base tables |
