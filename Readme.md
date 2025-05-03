# TaskManager API

A simple API developed as a study project to practice building a clean, scalable .NET application from scratch. This project focuses on implementing:

* **Clean Architecture**
* **Dependency Injection**
* **Entity Framework Core**
* **Docker containerization**
* **PostgreSQL integration**
* **Unit testing with xUnit**
* **Swagger for API documentation**

## 🛠 Technologies

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* Docker & Docker Compose
* xUnit (Unit Testing)
* AutoMapper
* Swagger (Swashbuckle)

## 📦 Running the Project with Docker

Make sure you have Docker Desktop and WSL2 properly configured. If you're using a drive other than C (e.g. D:), ensure it's shared with Docker.

```bash
docker-compose up --build
```

This will spin up both the API and the PostgreSQL database containers.

Access the API Swagger UI at:

```
http://localhost:5000/swagger
```

## 🧪 Running Tests

```bash
dotnet test
```

## 📁 Project Structure

```
TaskManager.Api/            --> Main Web API project
TaskManager.Application/    --> Business logic layer
TaskManager.Domain/			--> Entities and Enums
TaskManager.Infrastructure/ --> Data access (EF Core)
TaskManager.Tests/          --> Unit tests
```

## 📌 Notes

* Database connection is handled via dependency injection.
* Health checks and container dependencies are defined in the `docker-compose.yml`.
* Swagger auto-generates the OpenAPI documentation.
* Task retrieval and creation logic is encapsulated via service and repository layers.

## 🧑‍💻 Author

Developed by Guilherme Souza as a personal learning project. Contributions and feedback are welcome!
