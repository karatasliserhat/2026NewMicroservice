using _2026NewMicroservice.File.Api.features.file.delete;
using _2026NewMicroservice.File.Api.features.file.upload;
using Asp.Versioning.Builder;

namespace _2026NewMicroservice.File.Api.features.file
{
    public static class FileGroupEndpointExtension
    {
        public static void AddFileGroupEndpointExtension(this WebApplication app, ApiVersionSet apiVersionSet)
        {

            app.MapGroup("api/v{version:apiVersion}/files")
                .WithTags("Files")
                .MapUploadFileCommandEndpoint()
                .MapDeleteFileCommandEndpoint()
                .WithApiVersionSet(apiVersionSet)
                .DisableAntiforgery().
                RequireAuthorization();
        }
    }
}
