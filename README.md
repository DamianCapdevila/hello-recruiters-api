
# Hello Recruiter API

Welcome to the Hello Recruiter API! This API aims to greet recruiters from all over the world and provide essential functionalities for managing recruiter data.

Explore the API endpoints and test them using the Swagger documentation available [here](https://hello-recruiter-api.azurewebsites.net/swagger/index.html) !

## Overview

The Hello Recruiter API is a minimal API built with .NET and hosted on Azure Static Web Apps. It provides endpoints for basic CRUD operations on recruiter data, along with JWT authentication and user authorization.

Explanation on testing this API using Microsoft.AspNetCore.Mvc.Testing can be found in this readme in the TESTING section.

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


## Testing

To ensure the functionality of the Hello Recruiter API, the API is testeable. Below, an example test class built using the Microsoft.AspNetCore.Mvc.Testing and FluentAssertions packages.

### Example Test Class

The test class `HelloRecruitersApiTests` contains a test method `HelloRecruiterApiRootEndpointShouldReturnGreetingMessage` which verifies that the root endpoint of the API returns the expected greeting message.

```csharp
using FluentAssertions;
using HelloRecruiter.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace HelloRecruitersApi.Tests
{
    public class HelloRecruitersApiTests
    {
        public class Tests
        {
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public async Task HelloRecruiterApiRootEndpointShouldReturnGreetingMessage()
            {
                //Arrange
                var webApplicationfactory = new WebApplicationFactory<Program>().WithWebHostBuilder(webHostBuilder => { });
                var client = webApplicationfactory.CreateClient();
                var expectedResponse = "Hello Recruiters!!";

                //Act
                var response = await client.GetAsync("/").Result.Content.ReadAsStringAsync();

                //Assert
                response.Should().Be(expectedResponse);
            }
        }
    }
}
```

### Test Dependencies

The testing project relies on the following dependencies:

- `xUnit`: A unit testing framework.
- `FluentAssertions`: A fluent assertion library for .NET.
- `Microsoft.AspNetCore.Mvc.Testing`: Provides infrastructure for launching the ASP.NET Core app and making HTTP requests in tests.


## Author

- Damián Capdevila
- LinkedIn: [Damián Capdevila](https://www.linkedin.com/in/damiancapdevila/)
- GitHub: [DamianCapdevila](https://github.com/DamianCapdevila)

## License

This project is licensed under the [MIT License](LICENSE).
