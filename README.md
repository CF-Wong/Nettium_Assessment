# .NET 8 Web API Demo – Clean Architecture with Redis, RabbitMQ, and Serilog

This project is a demonstration of my skills in building a **.NET 8 Web API** using **Clean Architecture**, **Entity Framework Core (EF Core)**, and various integrations including:

- ✅ **RabbitMQ** – Message broker integration (publish-only)  
- ✅ **Redis** – Caching mechanism  
- ✅ **Serilog** – Structured logging  

It also features a lightweight **SQLite** database, making it easy to run without external database setup.

---

## 🚀 Features

- .NET 8 Web API
- Clean Architecture (Domain, Application, Infrastructure, and Web layers)
- Entity Framework Core with SQLite
- Redis caching
- RabbitMQ message publishing
- Serilog logging to console and files

---

## 📦 Tech Stack

| Technology | Purpose                     |
|------------|-----------------------------|
| .NET 8     | Web API Framework           |
| EF Core    | ORM                         |
| SQLite     | Lightweight embedded DB     |
| RabbitMQ   | Messaging queue             |
| Redis      | In-memory caching           |
| Serilog    | Logging                     |
| Clean Arch | Scalable architecture pattern |

---

## 🛠️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Redis and RabbitMQ running locally (e.g., via Docker)

### Run the Project

1. **Clone the repository**

       git clone https://github.com/CF-Wong/Nettium_Assessment.git
       cd Nettium_Assessment

2. **Restore and run**

       dotnet restore
       dotnet run --project Presentation/Nettium_Test.WebApi

> ✅ **No need to change connection strings** – SQLite is used for local development and doesn't require external setup.  
> ⚙️ Redis and RabbitMQ use default connection strings, which can be overridden in `appsettings.json` or environment variables:  
>  
> - **Redis:** `localhost:6379`  
> - **RabbitMQ:** `localhost:5672` (user: `guest`, password: `guest`)
> 
> 🛡️ Redis is optional – the app includes a fallback to prevent crashes if Redis is not configured.  

---

## 🧪 Testing the API

Once running, you can access:

- **Swagger UI**: `http://localhost:<port>/swagger`
- API documentation for health checks, caching, and RabbitMQ publishing

---

## 📤 RabbitMQ Integration

This project **only publishes messages to RabbitMQ**.

The **consumer implementation is intentionally excluded**, as it is expected to reside in a **separate backend service**, not the Web API itself. This aligns with **Clean Architecture principles** by separating background processing concerns from the API layer.

---

## 📝 Notes

- This is my **first time integrating RabbitMQ, Redis, and Serilog**, so feedback and suggestions are welcome!
- The structure is designed to follow **Clean Architecture** for scalability, maintainability, and testability.


