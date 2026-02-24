# 🎬 MovieLibraryApi

ASP.NET Core Web API for managing movies and reviews.

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core + SQL Server
- DTOs + Services + Dependency Injection
- Swagger UI

## Frontend
Frontend for this API can be found here:
[MovieLibraryFrontend](https://github.com/Megjafari/MovieLibraryFrontend)

## Getting Started

### Requirements
- .NET 8 SDK
- SQL Server

### Start the project
```bash
dotnet ef database update
dotnet run
```

Swagger UI: `https://localhost:7056/swagger`

## Endpoints

### Movies
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/Movies | Get all movies |
| GET | /api/Movies/{id} | Get a movie |
| POST | /api/Movies | Create a movie |
| PUT | /api/Movies/{id} | Update a movie |
| DELETE | /api/Movies/{id} | Delete a movie |

### Reviews
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/Reviews | Get all reviews |
| GET | /api/Reviews/{id} | Get a review |
| POST | /api/Reviews | Create a review |
| PUT | /api/Reviews/{id} | Update a review |
| DELETE | /api/Reviews/{id} | Delete a review |

## Data Model

**Movie**
- Id, Title, Description, ReleaseDate

**Review**
- Id, Comment, Rating (1-5), MovieId

## Screenshots

### Swagger UI
<img width="800" alt="Swagger UI" src="https://github.com/user-attachments/assets/8cbf8c0e-5cf0-4922-b9fd-80531c67410f" />
