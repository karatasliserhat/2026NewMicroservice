using _2026NewMicroservice.Shared;
using MediatR;
using Microsoft.Extensions.FileProviders;
using System.Net;

namespace _2026NewMicroservice.File.Api.features.file.upload
{
    public class UploadFileCommandHandler(IFileProvider fileProvider) : IRequestHandler<UploadFileCommand, ServiceResult<UploadFileResponse>>
    {
        public async Task<ServiceResult<UploadFileResponse>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            if (request.file is null || request.file.Length < 0)
                return ServiceResult<UploadFileResponse>.Error("file is required", "file is required", HttpStatusCode.BadRequest);


            string newName = $"{Guid.NewGuid()}{Path.GetExtension(request.file.FileName)}";

            string uploadPath = Path.Combine(fileProvider.GetFileInfo("files").PhysicalPath!, newName);

            using var stream = new FileStream(uploadPath, FileMode.Create);

            await request.file.CopyToAsync(stream, cancellationToken);

            var response = new UploadFileResponse(newName, $"files/{newName}", request.file.Name);

            return ServiceResult<UploadFileResponse>.SuccessAsCreated(response, response.FilePath);

        }
    }
}
