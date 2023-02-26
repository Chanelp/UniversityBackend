// 1. Usings to work with Entity Framework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// 2. TODO: CONNECTION WITH SQL SERVER EXPRESS
const string CONNECTION = "UniverityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION);

// 3. Add context to Services of builder
builder.Services.AddDbContext<UniverityDBContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();

// 4. Add Custom Services (folder Services)
builder.Services.AddScoped<IStudentsService, StudentsService>();
//TODO: Add the rest of services


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5. Habilitar CORS - CORS Generic Configurations
// (Quienes pueden realizar peticiones a nuestra api, desde quee entornos, métodos usar, headers a enviar)
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


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

// 6. Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();
