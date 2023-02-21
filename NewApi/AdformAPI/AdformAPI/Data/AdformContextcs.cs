using AdformAPI.Entites;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AdformAPI.Data
{
    public class AdformContextcs : IAdformContext
    {
        public AdformContextcs(IOptions<ConfiurationwithDatabase> configuration)
        {
            var client = new MongoClient(configuration.Value.ConnectionString);
            var database = client.GetDatabase(configuration.Value.DatabaseName);
            Products = database.GetCollection<AdformProduct>(configuration.Value.CollectionName);

        }


        public IMongoCollection<AdformProduct> Products { get; }
    }
}
