using CustomerMinimalAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGet("/", (HttpContext context) => new[] {
    $"http://{context.Request.Host}/customers",
    $"http://{context.Request.Host}/customers/1",
});

app.MapGet("/customers", (ICustomerRepository customerService) => {
    var customers = customerService.ReadAll();
    var dto = customers.Select(customer => new CustomerSummary(
        Id: customer.Id,
        Name: customer.Name,
        TotalNumberOfContracts: customer.Contracts.Count,
        NumberOfOpenContracts: customer.Contracts.Count(x => x.Work.State != WorkState.Completed)
    ));
    return dto;
});

app.MapGet("/customers/{id:int}", (ICustomerRepository customerService, int id) => {
    var customer = customerService.ReadOne(id);
    if (customer == default)
    {
        return Results.NotFound();
    }
    var dto = new CustomerDetails(
        Id: customer.Id,
        Name: customer.Name,
        Contracts: customer.Contracts.Select(contract => new ContractDetails(
            Id: contract.Id,
            Name: contract.Name,
            Description: contract.Description,

            // Flattening PrimaryContact
            PrimaryContactEmail: contract.PrimaryContact.Email,
            PrimaryContactFirstname: contract.PrimaryContact.Firstname,
            PrimaryContactLastname: contract.PrimaryContact.Lastname,

            // Flattening Work
            WorkDone: contract.Work.Done,
            WorkState: contract.Work.State.ToString(),
            WorkTotal: contract.Work.Total
        ))
    );
    return Results.Ok(dto);
});


app.Run();
