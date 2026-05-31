using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;

namespace _2026NewMicroservice.Shared.Extensions
{
    public static class ApiVersionSetExt
    {
        public static ApiVersionSet AddApiVersionSetExt(this WebApplication app)
        {
            var apiVersionSet = app.NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1, 0))
                .HasApiVersion(new ApiVersion(2, 0))
                .HasApiVersion(new ApiVersion(3, 0))
                .Build();
            return apiVersionSet;
        }
    }
}
