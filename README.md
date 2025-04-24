# Todo List Application

A web-based Todo List application built with ASP.NET Core, following object-oriented design principles and best practices.

## Features

- User management (registration, login, logout)
- Todo list management
- Task management
- RESTful API
- SQLite database
- JWT Authentication

## Project Structure

```
Todo.Web.Api/          # Web API project
Todo.Domain/           # Domain models and interfaces
Todo.Infrastructure/   # Database context and repositories
```

## Prerequisites

- .NET 6.0 SDK
- Visual Studio 2022 or Visual Studio Code
- SQLite
- Docker (optional, for containerized deployment)

## Local Development Setup

1. Clone the repository
2. Navigate to the project directory:
   ```bash
   cd Todo.Web.Api
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
4. Access the API documentation at: `http://localhost:5080/swagger`

## API Endpoints

### Authentication
- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - Login and get JWT token

### Users
- `POST /api/user` - Create a new user
- `GET /api/user/{id}` - Get user by ID
- `PUT /api/user/{id}` - Update user
- `DELETE /api/user/{id}` - Delete user

### Todo Lists
- `POST /api/todolist` - Create a new todo list
- `GET /api/todolist/{id}` - Get todo list by ID
- `PUT /api/todolist/{id}` - Update todo list
- `DELETE /api/todolist/{id}` - Delete todo list

### Tasks
- `POST /api/todotask` - Create a new task
- `GET /api/todotask/{id}` - Get task by ID
- `PUT /api/todotask/{id}` - Update task
- `DELETE /api/todotask/{id}` - Delete task

## Deployment

### Docker Deployment

1. Build the Docker image:
   ```bash
   docker build -t todo-app .
   ```

2. Run the container:
   ```bash
   docker run -d -p 8080:80 --name todo-app todo-app
   ```

3. Access the application at: `http://localhost:8080`

### Azure App Service Deployment

1. Create an Azure App Service
2. Configure the deployment source to your GitHub repository
3. Set the following environment variables:
   - `ASPNETCORE_ENVIRONMENT`: Production
   - `Jwt__Key`: Your production JWT key
   - `Jwt__Issuer`: Your production JWT issuer
   - `Jwt__Audience`: Your production JWT audience

## Technologies Used

- ASP.NET Core 6.0
- Entity Framework Core
- SQLite
- Swagger/OpenAPI
- C# 10.0
- JWT Authentication
- Docker

## Design Patterns

- Repository Pattern
- Dependency Injection
- MVC Pattern
- RESTful API Design

## License

This project is licensed under the MIT License. 