using _2026NewMicroservice.Payment.Api;
using _2026NewMicroservice.Payment.Api.Features.Payments;
using _2026NewMicroservice.Payment.Api.Repositories;
using _2026NewMicroservice.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddCommonServiceExt(typeof(PaymentAssembly));

builder.Services.AddVersioningExt();


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseInMemoryDatabase("payment-in-memory-db");
});

builder.Services.AddAuthenticationAndAuthorizationExt(builder.Configuration);

var app = builder.Build();

app.AddPaymentEndpointExtension(app.AddApiVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.Run();

