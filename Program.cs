using Final_project.Data;
using Final_project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<Cofeecontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API documentation for MyProject"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Sets Swagger UI at root (localhost:5000/)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Other configurations
app.MapControllers();

app.Run();

