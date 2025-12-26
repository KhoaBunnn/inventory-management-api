using Microsoft.EntityFrameworkCore;
using InventoryManagement.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext with InMemory Database (for quick testing)
// To use SQL Server, uncomment the line below and comment out the InMemory line
// builder.Services.AddDbContext<InventoryDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseInMemoryDatabase("InventoryDB"));

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Inventory Management API",
        Version = "v1",
        Description = "A simple REST API for managing inventory with products and categories",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com"
        }
    });
});

// Configure CORS (optional, for frontend integration)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Initialize database with seed data (for InMemory database)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
    context.Database.EnsureCreated(); // This will apply seed data from DbContext
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory Management API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at app's root
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
