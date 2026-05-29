using System.ComponentModel.DataAnnotations;

namespace _2026NewMicroservice.Catalog.API.Options
{
    public class MongoOption
    {
       [Required] public string ConnectionString { get; set; } = default!;
       [Required] public string DatabaseName { get; set; } = default!;
    }
}
