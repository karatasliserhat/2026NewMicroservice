using _2026NewMicroservice.Order.Api;
using _2026NewMicroservice.Order.Api.Endpoints;
using _2026NewMicroservice.Order.Application.Contracts.Repositories;
using _2026NewMicroservice.Order.Application.Contracts.UnitOfWork;
using _2026NewMicroservice.Order.Persistance.Context;
using _2026NewMicroservice.Order.Persistance.Contracts.Repositories;
using _2026NewMicroservice.Order.Persistance.Contracts.UnitOfWork;
using _2026NewMicroservice.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCommonServiceExt(typeof(OrderApplicationAssembly));
builder.Services.AddApiVersioning();

builder.Services.AddDbContext<AppDbContext>(opt
    => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.AddOrderEnpointExtension(app.AddApiVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.Run();
