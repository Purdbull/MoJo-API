var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/", () => "Hello World!");

/* ##########################################
 * ##             buildings                ##
 * ##########################################
 */

app.MapGet("/assets/buildings/", () => "not yet implemented");

app.MapGet("/assets/buildings/{id}/", () => "not yet implemented");

app.MapPost("/assets/buildings/", () => "not yet implemented");

app.MapPut("/assets/buildings/{id}/", () => "not yet implemented");

app.MapDelete("/assets/buildings/{id}/", () => "not yet implemented");


/* ##########################################
 * ##               storeys                ##
 * ##########################################
 */

app.MapGet("/assets/storeys/", () => "not yet implemented");

app.MapGet("/assets/storeys/{id}/", () => "not yet implemented");

app.MapPost("/assets/storeys/", () => "not yet implemented");

app.MapPut("/assets/storeys/{id}/", () => "not yet implemented");

app.MapDelete("/assets/storeys/{id}/", () => "not yet implemented");


/* ##########################################
 * ##               rooms                  ##
 * ##########################################
 */

app.MapGet("/assets/rooms/", () => "not yet implemented");

app.MapGet("/assets/rooms/{id}/", () => "not yet implemented");

app.MapPost("/assets/rooms/", () => "not yet implemented");

app.MapPut("/assets/rooms/{id}/", () => "not yet implemented");

app.MapDelete("/assets/rooms/{id}/", () => "not yet implemented");

app.Run();