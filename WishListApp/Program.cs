using Microsoft.Extensions.Options;
using WishListApp;
using WishListApp.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services
.ConfigureOptions<InMemoryWishListOptions>()
.AddTransient<IValidateOptions<InMemoryWishListOptions>,InMemoryWishListOptions>()
.AddSingleton(serviceProvider => serviceProvider
.GetRequiredService<IOptions<InMemoryWishListOptions>>().Value)
.AddSingleton<IWishList, InMemoryWishList>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
