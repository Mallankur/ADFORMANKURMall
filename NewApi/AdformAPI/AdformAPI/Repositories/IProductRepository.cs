using AdformAPI.Entites;

namespace AdformAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<AdformProduct>> GetAllAdformProductsAsync();
        Task<IEnumerable<AdformProduct>> GetAdformProductById(string id);
       // Task<IEnumerable<AdformProduct>> GetProductByName(string name);
        Task  createProduct(AdformProduct product);
       // Task<bool> UpdateProduct(AdformProduct product);
       // Task<bool> DeleteProduct(string id); 
    }
}
