
# Hello Recruiter API

Welcome to the Hello Recruiter API! This API aims to greet recruiters from all over the world and provide essential functionalities for managing recruiter data.

## Overview

The Hello Recruiter API is a minimal API built with .NET and hosted on Azure Static Web Apps. It provides endpoints for basic CRUD operations on recruiter data, along with JWT authentication and user authorization.

## Authentication

The API utilizes JWT (JSON Web Token) authentication. To authenticate, use the following credentials:

- **Username:** random_standard
- **Password:** MyPassword1234!

## Swagger Documentation

Explore the API endpoints and test them using the Swagger documentation available [here](https://hello-recruiter-api.azurewebsites.net/swagger/index.html).

## Dependencies

The API uses dependency injection for the authorization service and the methods mapped to the API endpoints. Key dependencies include:

- `IRecruiterService`: Service for managing recruiter data.
- `IUserService`: Service for user-related operations.

## Endpoints

- **GET /**  
  Gets a welcome message for all recruiters.

- **POST /login**  
  Provides a login mechanism.

- **GET /list**  
  Gets all recruiters.

- **GET /get**  
  Gets a recruiter by its ID. (Authorization required)

- **POST /create**  
  Creates a new recruiter. (Authorization required)

- **PUT /update**  
  Updates a recruiter. (Authorization required)

- **DELETE /delete**  
  Deletes a recruiter by its ID. (Authorization required)

## Author

- Damián Capdevila
- LinkedIn: [Damián Capdevila](https://www.linkedin.com/in/damiancapdevila/)
- GitHub: [DamianCapdevila](https://github.com/DamianCapdevila)

## License

This project is licensed under the [MIT License](LICENSE).
