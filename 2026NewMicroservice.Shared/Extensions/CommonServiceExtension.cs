using _2026NewMicroservice.Shared.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace _2026NewMicroservice.Shared.Extensions
{
    public static class CommonServiceExtension
    {
        public static IServiceCollection AddCommonServiceExt(this IServiceCollection services, Type assembly)
        {
            services.AddHttpContextAccessor();

            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(assembly));

            services.AddValidatorsFromAssemblyContaining(assembly);

            services.AddAutoMapper(cfg => { }, assembly);

            services.AddScoped<IIdentityService, IdentityService>();

            services.AddSwaggerGen();

            return services;
        }
    }
}
