using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/Finding", ([FromServices] ILogger logger, [FromQuery] string UserInput) =>
{
    logger.LogInformation("Unsanitized user input " + UserInput);
    return "Hello World!";
});

app.MapGet("/Sanitized", ([FromServices] ILogger logger, [FromQuery] string UserInput) =>
{
    logger.LogInformation("Sanitized user input " + UserInput.Replace(Environment.NewLine, string.Empty));
    return "Hello World!";
});

app.MapGet("/SanitizedWithFinding", ([FromServices] ILogger logger, [FromQuery] string UserInput) =>
{
    logger.LogInformation("Sanitized user input" + logger.Sanitize(UserInput));
    return "Hello World!";
});

app.MapRazorPages();
app.MapControllers();
app.Run();


public static class LoggerExtensions
{
    public static string Sanitize(this ILogger _, string message)
    {
        return message.Replace(Environment.NewLine, string.Empty);
    }
}