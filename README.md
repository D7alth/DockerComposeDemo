# Docker Compose Demo App 🐳

A weekend project to explore Docker Compose with a .NET 10 API and PostgreSQL. Nothing fancy—just a simple Todo API to test container orchestration and service communication.

## Overview

Minimal .NET API connected to PostgreSQL, all running in Docker containers. Built this to experiment with Docker Compose configuration and see how everything plays together.

## Stack

- .NET 10 Minimal API
- PostgreSQL
- Entity Framework Core with Npgsql
- Docker Compose

## Features

Simple CRUD operations for a Todo model (Title, Description, IsCompleted).

## Quick Start

```bash
docker-compose up
dotnet ef database update
```

API runs on `http://localhost:8080`

## Endpoints

- `GET /todos` - List all todos
- `POST /todos` - Create a todo

---

*Weekend experiment with Docker Compose orchestration. Feel free to fork and mess around with it.*






