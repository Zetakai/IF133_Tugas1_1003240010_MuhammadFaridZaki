using IF133.Tugas1.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrasi controller (Web API berbasis controller).
builder.Services.AddControllers();

// Registrasi DbContext melalui dependency injection.
// Connection string dibaca dari appsettings.json, bukan di-hardcode di controller.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger / OpenAPI untuk pengujian endpoint.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "IF133 Tugas 1 - Product API",
        Version = "v1",
        Description = "Backend skeleton ASP.NET Core Web API + EF Core (SQLite)."
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1");
        // Swagger UI terbuka langsung di root: http://localhost:5116/
        options.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
