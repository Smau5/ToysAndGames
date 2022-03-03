using Microsoft.EntityFrameworkCore;
using ToysAndGames.Infrastructure;
using ToysAndGames.Services;
using ToysAndGames.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
    string connectionString = builder.Configuration["Database:ConnectionString"];
    optionsBuilder.UseSqlServer(connectionString,
        o => o.MigrationsAssembly("ToysAndGames.Infrastructure"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//TODO: Logic should not be in the controllers, lets move them to Services
//TODO: Rename Infrastructure Proyect to Data and Include the Models there from Core to Data
//TODO: Create autoStartup for DB Migrations
//TODO: Create Configuration Files for Entities
//TODO: Move Seed Data to HasData on the Data configuration Files


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }