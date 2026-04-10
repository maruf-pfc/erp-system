# ERP System — Frontend

Next.js 15 frontend for the ERP system using App Router, TypeScript, and shadcn/ui.

> ⚠️ Frontend development starts after backend APIs are complete.

## Tech Stack

- Next.js 15 (App Router)
- TypeScript
- Tailwind CSS
- shadcn/ui
- Zustand (State)
- Axios (HTTP)
- pnpm

## Prerequisites

- Node.js 20+
- pnpm

```bash
npm install -g pnpm
```

## Setup

```bash
pnpm install
cp .env.example .env.local
pnpm dev
```

App runs at: `http://localhost:3000`

## Environment Variables

`.env.local`

```txt
NEXT_PUBLIC_API_URL=https://localhost:5001
NEXT_PUBLIC_APP_NAME=ERP System
```

## Folder Structure

```txt
src/
├── app/              # Next.js App Router pages
├── components/
│   ├── ui/           # shadcn primitives
│   ├── layout/       # Sidebar, Navbar
│   └── shared/       # Reusable components
├── features/         # Feature-based modules
│   ├── hr/
│   ├── finance/
│   ├── inventory/
│   ├── crm/
│   └── procurement/
├── hooks/            # Custom React hooks
├── lib/              # axios instance, utils
├── services/         # API call functions
├── store/            # Zustand stores
└── types/            # Global TypeScript types
```

## Module Pages (Planned)

| Route                 | Module      |
| --------------------- | ----------- |
| `/dashboard`          | Overview    |
| `/hr/employees`       | HR          |
| `/finance/invoices`   | Finance     |
| `/inventory/products` | Inventory   |
| `/crm/customers`      | CRM         |
| `/procurement/orders` | Procurement |
