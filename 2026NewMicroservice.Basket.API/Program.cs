using _2026NewMicroservice.Basket.API;
using _2026NewMicroservice.Basket.API.Features.Basket;
using _2026NewMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddCommonServiceExt(typeof(BasketAssembly));

builder.Services.AddVersioningExt();


builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddScoped<BasketService>();

var app = builder.Build();

app.AddBasketEndpoints(app.AddApiVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}




app.Run();

