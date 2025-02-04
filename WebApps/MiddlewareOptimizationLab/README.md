## Goals

### Simulated HTTPS Enforcement
Use a query parameter to simulate HTTPS enforcement. If the `secure=true` parameter is missing, the middleware should block the request as if it were non-HTTPS.

```csharp
app.Use(async (context, next) =>
{
    if (context.Request.Query["secure"] != "true")
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Simulated HTTPS Required");
        return;
    }
    await next();
});
```

### Short-Circuit Unauthorized Access
Stop further processing for unauthorized requests.

```csharp
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/unauthorized")
    {
        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized Access");
        }
        return;
    }
    await next();
});
```

### Asynchronous Processing
Implement asynchronous methods to handle I/O operations without blocking other requests.

```csharp
app.Use(async (context, next) =>
{
    await Task.Delay(100); // Simulate async operation
    if (!context.Response.HasStarted)
    {
        await context.Response.WriteAsync("Processed Asynchronously\n");
    }
    await next();
});
```

### Input Validation
Validate incoming request data and sanitize any unsafe input.

```csharp
app.Use(async (context, next) =>
{
    var input = context.Request.Query["input"];
    if (!IsValidInput(input))
    {
        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid Input");
        }
        return;
    }
    await next();
});

static bool IsValidInput(string input)
{
    return string.IsNullOrEmpty(input) || (input.All(char.IsLetterOrDigit) && !input.Contains("<script>"));
}
```

### Authentication Checks
Add early authentication checks to restrict access for unauthenticated users.

```csharp
app.Use(async (context, next) =>
{
    var isAuthenticated = context.Request.Query["authenticated"] == "true";
    if (!isAuthenticated)
    {
        if (!context.Response.HasStarted)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Access Denied");
        }
        return;
    }

    context.Response.Cookies.Append("SecureCookie", "SecureData", new CookieOptions
    {
        HttpOnly = true,
        Secure = true
    });

    await next();
});
```

### Security Event Logging
Log security events for any blocked or failed requests.

```csharp
app.Use(async (context, next) =>
{
    await next(); // Run the next middleware first

    if (context.Response.StatusCode >= 400)
    {
        Console.WriteLine($"Security Event: {context.Request.Path} - Status Code: {context.Response.StatusCode}");
    }
});
```