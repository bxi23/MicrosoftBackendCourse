# DeserializationDemo

This is a simple ASP.NET Core web application demonstrating JSON deserialization.

## Endpoints

- `GET /`: Returns "Hello World".
- `POST /auto`: Accepts a JSON object and returns it.
- `POST /json`: Accepts a JSON object, validates it, and adds it to a list if valid.
- `POST /custom-options`: Accepts a JSON object with custom deserialization options.
- `GET /json`: Returns the list of all valid JSON objects received.

## Running the Application

1. Open the project in Visual Studio.
2. Press `F5` to run the application.
3. Use the `requests.http` file to test the endpoints.

## Person Class

The `Person` class represents the data structure for the JSON objects:

```csharp
public class Person
{
    public string UserName { get; set; }
    public int UserAge { get; set; }
}
```

## Configuration

The application uses the following configuration files:

- `appsettings.json`: General settings.
- `appsettings.Development.json`: Development-specific settings.

## Launch Settings

The `launchSettings.json` file contains profiles for running the application:

- `http`: Runs the application on `http://localhost:5194`.
- `https`: Runs the application on `https://localhost:7027` and `http://localhost:5194`.

## Dependencies

The project targets `.NET 9.0` and uses the following frameworks:

- `Microsoft.AspNetCore.App`
- `Microsoft.NETCore.App`

