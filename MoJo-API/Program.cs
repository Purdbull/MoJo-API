using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DB_Connection");
builder.Services.AddDbContext<MoJo_API.DataBase>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

/* ##########################################
 * ##          CRUD for buildings          ##
 * ##########################################
 */

app.MapGet("/assets/buildings/", async (MoJo_API.DataBase db) => await db.Buildings.ToListAsync());  //something wrong

app.MapGet("/assets/buildings/{id}/", () => "not yet implemented");

app.MapPost("/assets/buildings/", () => "not yet implemented");

app.MapPut("/assets/buildings/{id}/", () => "not yet implemented");

app.MapDelete("/assets/buildings/{id}/", () => "not yet implemented");


/* ##########################################
 * ##           CRUD for storeys           ##
 * ##########################################
 */

app.MapGet("/assets/storeys/", () => "not yet implemented");

app.MapGet("/assets/storeys/{id}/", () => "not yet implemented");

app.MapPost("/assets/storeys/", () => "not yet implemented");

app.MapPut("/assets/storeys/{id}/", () => "not yet implemented");

app.MapDelete("/assets/storeys/{id}/", () => "not yet implemented");


/* ##########################################
 * ##           CRUD for rooms             ##
 * ##########################################
 */

app.MapGet("/assets/rooms/", () => "not yet implemented");

app.MapGet("/assets/rooms/{id}/", () => "not yet implemented");

app.MapPost("/assets/rooms/", () => "not yet implemented");

app.MapPut("/assets/rooms/{id}/", () => "not yet implemented");

app.MapDelete("/assets/rooms/{id}/", () => "not yet implemented");





app.Run();

record Building(int ID)
{
    public string id { get; set; } = default!;
    public string name { get; set; } = default!;
    public string adress { get; set; } = default!;
}