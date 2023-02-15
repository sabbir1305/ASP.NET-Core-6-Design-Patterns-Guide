

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSingleton<OperationDesignPatternAPI.SimplestForm.Executor>()
    .AddSingleton<OperationDesignPatternAPI.SingleError.Executor>()
    .AddSingleton<OperationDesignPatternAPI.SingleErrorWithValue.Executor>();

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

app.MapGet("/simplest-form", (OperationDesignPatternAPI.SimplestForm.Executor executor) =>
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

app.MapGet("/single-error", (OperationDesignPatternAPI.SingleError.Executor executor) =>
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
        return result.ErrorMessage;
    }
});

app.MapGet("/single-error-with-value", (OperationDesignPatternAPI.SingleErrorWithValue.Executor executor) =>
{
    var result = executor.Operation();
    if (result.Succeeded)
    {
        // Handle the success
        return $"Operation succeeded with a value of '{result.Value}'.";
    }
    else
    {
        // Handle the failure
        return $"Operation failed for '{result.Value}'";
    }
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.Run();
