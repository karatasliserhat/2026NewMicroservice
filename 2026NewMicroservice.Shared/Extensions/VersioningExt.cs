using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace _2026NewMicroservice.Shared.Extensions
{
    public static class VersioningExt
    {
        public static IServiceCollection AddVersioningExt(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = new UrlSegmentApiVersionReader();
                //opt.ApiVersionReader = ApiVersionReader.Combine(
                //    new UrlSegmentApiVersionReader(),
                //    new HeaderApiVersionReader("x-api-version"),
                //    new MediaTypeApiVersionReader("x-api-version")
                //);

            }).AddApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'V";
                opt.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
