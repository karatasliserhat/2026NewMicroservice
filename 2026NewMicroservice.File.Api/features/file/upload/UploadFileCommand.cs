using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.File.Api.features.file.upload
{
    public record UploadFileCommand(IFormFile file):IRequestServiceResult<UploadFileResponse>;
    
}
