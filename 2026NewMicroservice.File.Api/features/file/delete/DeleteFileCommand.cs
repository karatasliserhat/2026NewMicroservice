using _2026NewMicroservice.Shared;

namespace _2026NewMicroservice.File.Api.features.file.delete
{
    public record DeleteFileCommand(string FileName):IRequestServiceResult;
}
