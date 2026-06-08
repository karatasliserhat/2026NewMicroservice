using _2026NewMicroservice.File.Api;
using _2026NewMicroservice.File.Api.features.file;
using _2026NewMicroservice.Shared.Extensions;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCommonServiceExt(typeof(FileAssembly));

builder.Services.AddVersioningExt();


builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.AddFileGroupEndpointExtension(app.AddApiVersionSetExt());

app.Run();


