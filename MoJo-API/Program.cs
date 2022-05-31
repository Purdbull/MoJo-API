using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

app.MapGet("/assets/buildings/", async (MoJo_API.DataBase db) => await db.buildings.ToListAsync());

app.MapGet("/assets/buildings/{id}/", async (Guid id,MoJo_API.DataBase db) => {
    // looking for the building with the requested id
    return await db.buildings.FindAsync(id)
            // checks weather the result of the operation before is a building or not 
            is building n
                // Result is building. Return with Code: 200
                ? Results.Ok(n)
                // Result wasnt a building object. building could not befound in the table. Return with Code:404
                : Results.NotFound();
});

app.MapPost("/assets/buildings/", async (building b, MoJo_API.DataBase db) => {

    //building may contain a uuid. If so, we "put" it in our database
    if(b.id == Guid.Empty)
    {
        b.id = Guid.NewGuid(); //generating id if there wasnt one
        db.buildings.Add(b);
        await db.SaveChangesAsync();
        return Results.CreatedAtRoute();
    }

    Guid id = b.id;
    var building = await db.buildings.FindAsync(id);

    if (building is null) return Results.NotFound();


    //found, so update with incoming building n.
    building.address = b.address;
    building.name = b.name;
    await db.SaveChangesAsync();
    return Results.Ok(building);
});

app.MapPut("/assets/buildings/{id}/", async (Guid id, building n, MoJo_API.DataBase db) =>
{
    // check if id of the .json-object matches the requested id 
    if (n.id != id)
    {
        // id's do not match response with Code: 400 
        return Results.BadRequest();
    }

    var building = await db.buildings.FindAsync(id);

    if (building is null) return Results.NotFound();

    //found, so update with incoming building n.
    building.address = n.address;
    building.name = n.name;
    await db.SaveChangesAsync();
    return Results.Ok(building);
});

app.MapDelete("/assets/buildings/{id}/", async (Guid id, MoJo_API.DataBase db) => {

    //removing every storey and room in that building
    IEnumerable<storey> existingStoreysForThatBuilding = db.storeys.Where(storey => storey.building_id == id);
    foreach(storey Storey in existingStoreysForThatBuilding)
    {
        Guid storeyId = Storey.id;
        db.storeys.Remove(Storey);

        IEnumerable<room> existingRoomsForThatStorey = db.rooms.Where(room => room.storey_id == storeyId);
        foreach (room Room in existingRoomsForThatStorey)
        {
            db.rooms.Remove(Room);
        }
    }

    var building = await db.buildings.FindAsync(id);
    if (building is not null)
    {
        db.buildings.Remove(building);
        await db.SaveChangesAsync();
    }
    return Results.NoContent();
});


/* ##########################################
 * ##           CRUD for storeys           ##
 * ##########################################
 */

app.MapGet("/assets/storeys/", async (MoJo_API.DataBase db) => await db.storeys.ToListAsync());

app.MapGet("/assets/storeys/{id}/" , async (Guid id, MoJo_API.DataBase db) => {
    return await db.storeys.FindAsync(id)
            is storey n
                ? Results.Ok(n)
                : Results.NotFound();
});

app.MapPost("/assets/storeys/", () => "not yet implemented");

app.MapPut("/assets/storeys/{id}/", () => "not yet implemented");

app.MapDelete("/assets/storeys/{id}/", () => "not yet implemented");


/* ##########################################
 * ##           CRUD for rooms             ##
 * ##########################################
 */

app.MapGet("/assets/rooms/", async (MoJo_API.DataBase db) => await db.rooms.ToListAsync());

app.MapGet("/assets/rooms/{id}/" , async (Guid id, MoJo_API.DataBase db) => {
    return await db.rooms.FindAsync(id)
            is room n
                ? Results.Ok(n)
                : Results.NotFound();
});

app.MapPost("/assets/rooms/", () => "not yet implemented");

app.MapPut("/assets/rooms/{id}/", () => "not yet implemented");

app.MapDelete("/assets/rooms/{id}/", () => "not yet implemented");





app.Run();



/* #######################################
 * ##          helper methods           ##
 * #######################################
 */




 // Guid equals uiid in c#
public class building
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
}

public class room
{
    public Guid id { get; set; }
    public string name { get; set; }
    public Guid storey_id { get; set; }
}

public class storey
{
   
    public Guid id { get; set; }
    public string name { get; set; }
    public Guid building_id { get; set; }
}