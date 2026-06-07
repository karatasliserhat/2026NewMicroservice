using _2026NewMicroservice.Discount.API;
using _2026NewMicroservice.Discount.API.Features.Discounts;
using _2026NewMicroservice.Discount.API.Options;
using _2026NewMicroservice.Discount.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCommonServiceExt(typeof(DiscountAssembly));

builder.Services.AddMongoOptionExt();
builder.Services.AddDatabaseMongoExt();

builder.Services.AddApiVersioning();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddDiscountGroupEndpointExt(app.AddApiVersionSetExt());

app.Run();

