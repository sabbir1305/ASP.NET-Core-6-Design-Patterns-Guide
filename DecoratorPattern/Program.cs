using DecoratorPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IComponent>(serviceProvider => new DecoratorB(new DecoratorA(new ComponentA())));
var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapGet("/", (IComponent component) => component.Operation());

app.Run();
