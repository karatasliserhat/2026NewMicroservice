using _2026NewMicroservice.Catalog.API;
using _2026NewMicroservice.Catalog.API.Features.Categories;
using _2026NewMicroservice.Catalog.API.Features.Courses;
using _2026NewMicroservice.Catalog.API.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddOptionExtension();
builder.Services.AddDatabaseServiceExtension();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));

var app = builder.Build();

app.AddCategoryGroupEndpointExt();

app.AddCourseGroupEndpointExt();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();

