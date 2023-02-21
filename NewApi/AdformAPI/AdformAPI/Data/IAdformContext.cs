using AdformAPI.Entites;
using MongoDB.Driver;

namespace AdformAPI.Data
{
    public interface IAdformContext
    {
        IMongoCollection<AdformProduct> Products { get; }

    }
}
