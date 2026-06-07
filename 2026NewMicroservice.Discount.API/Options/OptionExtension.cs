using Microsoft.Extensions.Options;

namespace _2026NewMicroservice.Discount.API.Options
{
    public static class OptionExtension
    {
        public static void AddMongoOptionExt(this IServiceCollection services)
        {
            services.AddOptions<MongoOption>().BindConfiguration(nameof(MongoOption))
                .ValidateDataAnnotations()
                .ValidateOnStart();


            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);
        }
    }
}
