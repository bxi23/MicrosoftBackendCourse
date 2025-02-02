# LoggingLab-Solution

## Serilog Configuration

### Basics of Serilog Configuration

Serilog is a structured logging library for .NET applications. It allows developers to log messages to various outputs, such as the console, files, databases, and more. The configuration of Serilog in this application is done in the `Program.cs` file.

```csharp
var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

Why Serilog is Used in This Application
Serilog is used in this application to provide robust and flexible logging capabilities. It helps in:

Capturing detailed logs for debugging and monitoring.
Structuring logs in a way that makes them easy to query and analyze.
Handling exceptions and errors gracefully by logging them and providing meaningful responses to the client.
Application Concept and Functionality
Concept
This application is a simple ASP.NET Core web API that demonstrates error handling and logging using Serilog. It includes a controller that performs a division operation and handles division by zero errors.

How It Functions
Startup Configuration:

The application is configured to use Serilog for logging.
Controllers are added to the service container.
Middleware for Error Handling:

A middleware is configured to catch any unhandled exceptions, log them using Serilog, and return a 500 status code with a generic error message.
Routing and Endpoints:

The application uses routing to map controller endpoints.
The ErrorHandlingController is mapped to handle requests for division operations.
ErrorHandlingController:

The controller has an endpoint /api/ErrorHandling/division that takes two query parameters: numerator and denominator.
It performs the division operation and returns the result.
If a division by zero occurs, it catches the DivideByZeroException, logs the error, and returns a BadRequest response.
Example Requests
Valid Division:

GET http://localhost:5153/api/ErrorHandling/division?numerator=10&denominator=2