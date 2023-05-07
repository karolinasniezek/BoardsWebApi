using Boards.Context;
using Boards.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BoardsDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<BoardsDbContext>();

var users = dbContext.Users.ToList();
if (!users.Any())
{
    var user1 = new User()
    {
        Email = "user1@gmail.com",
        FullName = "User One",
        Address = new Address() { City = "Wroc³aw", Street = "Prosta" }
    };

    var user2 = new User()
    {
        Email = "user2@gmail.com",
        FullName = "User Two",
        Address = new Address() { City = "Krakow", Street = "D³uga" }
    };
    dbContext.Users.AddRange(user1, user2);
    dbContext.SaveChanges();
}

app.Run();
