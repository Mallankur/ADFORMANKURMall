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

        /// <summary>
        /// Create the product  in Database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public   async Task createProduct(AdformProduct product)
        {
             await _context.Products.InsertOneAsync(product); 
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var filter =  Builders<AdformProduct>.Filter.Eq(x=>x.Id, id);
            var res =   await _context.Products.DeleteOneAsync(filter);

            if (res is null)
            {
                return false;
            }
            return true;    
            
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

        public Task<IEnumerable<AdformProduct>> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateProduct(AdformProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
