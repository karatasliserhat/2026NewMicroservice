using Microsoft.Extensions.Options;

namespace _2026NewMicroservice.Catalog.API.Options
{
    public static class OptionExtension
    {
        public static IServiceCollection AddOptionExtension(this IServiceCollection services)
        {
            services.AddOptions<MongoOption>().BindConfiguration(nameof(MongoOption)).ValidateDataAnnotations().ValidateOnStart();

            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);

            return services;
        }
    }
}
