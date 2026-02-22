# Docker Compose Demo App 🐳
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
```

API runs on `http://192.168.0.65:8080` (DOCKER_HOST_IP) and connects to PostgreSQL at `postgres:5432` (service name in Docker Compose).

## Endpoints

- `GET /todos` - List all todos
- `POST /todos` - Create a todo

---

*Weekend experiment with Docker Compose orchestration. Feel free to fork and mess around with it.*






