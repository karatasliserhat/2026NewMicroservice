using _2026NewMicroservice.Catalog.API.Options;
using MongoDB.Driver;

namespace _2026NewMicroservice.Catalog.API.Repositories
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddDatabaseServiceExtension(this IServiceCollection services)
        {

            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {

                var mongoOption = sp.GetRequiredService<MongoOption>();
                return new MongoClient(mongoOption.ConnectionString);
            });

            services.AddScoped(sp =>
            {

                var mongoOption = sp.GetRequiredService<MongoOption>();
                var client = sp.GetRequiredService<IMongoClient>();
                return AppDbContext.Create(client.GetDatabase(mongoOption.DatabaseName));
            });

            return services;



        }
    }
}
