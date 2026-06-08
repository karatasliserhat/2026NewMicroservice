using _2026NewMicroservice.Shared;
using MediatR;
using Microsoft.Extensions.FileProviders;
using System.Net;

namespace _2026NewMicroservice.File.Api.features.file.delete
{
    public class DeleteFileCommandHandler(IFileProvider fileProvider) : IRequestHandler<DeleteFileCommand, ServiceResult>
    {
        public Task<ServiceResult> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.FileName))
                return Task.FromResult(ServiceResult.Error("fileName not null", "require is File Name", HttpStatusCode.BadRequest));

            var uploadPath = Path.Combine(fileProvider.GetFileInfo("files").PhysicalPath!, request.FileName);

            System.IO.File.Delete(uploadPath);

            return Task.FromResult(ServiceResult.SuccessAsNoContent());
        }
    }
}
