using AdformAPI.Data;
using AdformAPI.Entites;
using MongoDB.Driver;

namespace AdformAPI.Repositories
{
    public class ProductRipositorycs : IProductRepository
    {

        private readonly IAdformContext _context;
        public ProductRipositorycs(IAdformContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task createProduct(AdformProduct product)
        {
             await _context.Products.InsertOneAsync(product); 
        }

        public async Task<IEnumerable<AdformProduct>> GetAdformProductById(string id)
        {
            var filter = Builders<AdformProduct>.Filter.Eq(x => x.Id, id);
            return 
                 await _context.Products.Find(filter).ToListAsync();    
        }

        public async Task<IEnumerable<AdformProduct>> GetAllAdformProductsAsync()
        {
            return await _context.
                        Products
                        .Find(_ => true).ToListAsync();
        }
    }
}
