using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/Finding", (ILogger logger, [FromQuery] string UserInput) =>
{
    logger.LogInformation("Unsanitized user input " + UserInput);
    return "Hello World!";
});

app.MapGet("/Sanitized", (ILogger logger, [FromQuery] string UserInput) =>
{
    logger.LogInformation("Sanitized user input " + UserInput.Replace(Environment.NewLine, string.Empty));
    return "Hello World!";
});

app.MapGet("/SanitizedWithFinding", (ILogger logger, [FromQuery] string UserInput) =>
{
    logger.LogInformation("Sanitized user input" + logger.Sanitize(UserInput));
    return "Hello World!";
});

app.Run();


public static class LoggerExtensions
{
    public static string Sanitize(this ILogger _, string message)
    {
        return message.Replace(Environment.NewLine, string.Empty);
    }
}