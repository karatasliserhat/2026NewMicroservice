using _2026NewMicroservice.Order.Persistance.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContext>(opt 
    => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}




app.Run();
