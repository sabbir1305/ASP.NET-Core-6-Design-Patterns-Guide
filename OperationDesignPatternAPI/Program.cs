using OperationDesignPatternAPI.SimplestForm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSingleton<Executor>();

var app = builder.Build();
app.MapGet("/", () =>
{
    return new[]
    {
        "/simplest-form",
        "/single-error",
        "/single-error-with-value",
        "/multiple-errors-with-value",
        "/multiple-errors-with-value-and-severity",
        "/static-factory-methods",
    };
});

app.MapGet("/simplest-form", (Executor executor) =>
{
    var result = executor.Operation();
    if (result.Succeeded)
    {
        // Handle the success
        return "Operation succeeded";
    }
    else
    {
        // Handle the failure
        return "Operation failed";
    }
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.Run();
