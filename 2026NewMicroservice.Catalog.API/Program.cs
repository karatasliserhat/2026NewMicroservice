using _2026NewMicroservice.Catalog.API;
using _2026NewMicroservice.Catalog.API.Features.Categories;
using _2026NewMicroservice.Catalog.API.Features.Courses;
using _2026NewMicroservice.Catalog.API.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddOptionExtension();
builder.Services.AddDatabaseServiceExtension();


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));

builder.Services.AddVersioningExt();

builder.Services.AddAuthenticationAndAuthorizationExt(builder.Configuration);

var app = builder.Build();

app.AddSeedData().ContinueWith(x => { Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed data added."); });

app.AddCategoryGroupEndpointExt(app.AddApiVersionSetExt());

app.AddCourseGroupEndpointExt(app.AddApiVersionSetExt());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

