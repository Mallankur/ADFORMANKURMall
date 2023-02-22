using AdformAPI.Entites;
using AdformAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net;
using System.Runtime.CompilerServices;

namespace AdformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdformController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<AdformController> _logger; 
        public AdformController(IProductRepository productRepository, ILogger<AdformController> logger)
        {
            _productRepository = productRepository?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger?? throw new ArgumentNullException(nameof(logger)); 
            
        }
        /// <summary>
        /// Get the data in Database 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AdformProduct>), ((int)HttpStatusCode.OK))]

        public async Task <IActionResult> GetProdocts()
        {
            var product = await _productRepository.GetAllAdformProductsAsync();
            if (product is null)
            {
                return null;
            }

            return Ok(product); 
        }
        /// <summary>
        /// Post the data in database 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(AdformProduct), ((int)HttpStatusCode.OK))]

        public async Task <IActionResult> CreateProduct([FromBody]AdformProduct product)
        {
            await _productRepository.createProduct(product);  
            return Ok(product);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(AdformProduct), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByid(string id)
        {
            var pdt =  await _productRepository.GetAdformProductById(id);
            if (pdt is null)
            {
                _logger.LogError($"Product with id {id} , not found .");
                return NotFound();  
            }
            return Ok(pdt);

        }


    }
}
