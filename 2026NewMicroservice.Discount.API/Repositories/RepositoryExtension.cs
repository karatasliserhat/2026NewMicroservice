using _2026NewMicroservice.Discount.API.Options;
using MongoDB.Driver;

namespace _2026NewMicroservice.Discount.API.Repositories
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddDatabaseMongoExt(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var mongoOption = sp.GetRequiredService<MongoOption>();

                return new MongoClient(mongoOption.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                var mongoOption = sp.GetRequiredService<MongoOption>();
                var mongoClient = sp.GetRequiredService<IMongoClient>();

                return AppDbContext.Create(mongoClient.GetDatabase(mongoOption.DatabaseName));
            });

            return services;
        }
    }
}
