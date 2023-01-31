// 1. Usings to work with Entity Framework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// 2. TODO: CONNECTION WITH SQL SERVER EXPRESS
const string CONNECTION = "UniverityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTION);

// 3. Add context to Services of builder
builder.Services.AddDbContext<UniverityDBContext>(options => options.UseSqlServer(connectionString));


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
