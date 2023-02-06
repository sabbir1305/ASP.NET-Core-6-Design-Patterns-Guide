using BookStore_CompositePattern;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ICorporationFactory,
DefaultCorporationFactory>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/", async (HttpContext context, ICorporationFactory
corporationFactory) =>
{
    var compositeDataStructure = corporationFactory.Create();
    var output = compositeDataStructure.Display();
    context.Response.Headers.Add("Content-Type", HtmlSnippet.CONTENT_TYPE);
    await context.Response.WriteAsync(HtmlSnippet.HEADER);
    await context.Response.WriteAsync(output);
    await context.Response.WriteAsync(HtmlSnippet.FOOTER);
});

app.UseHttpsRedirection();




app.Run();

