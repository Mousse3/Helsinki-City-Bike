using Microsoft.EntityFrameworkCore;
using HBike.Models;


foreach (String arg in Environment.GetCommandLineArgs())
{
    if (arg.Equals("initdb"))
    {
        using (var context = new HBikeContext())
        {
            context.Database.EnsureCreated();

            context.TestItems.Add(new TestItem { Name = "Lisätty testissä", IsComplete = false });
            context.SaveChanges();
        }
    }
}



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HBikeContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
