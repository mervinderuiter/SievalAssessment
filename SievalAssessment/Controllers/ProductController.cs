using Microsoft.AspNetCore.Mvc;
using SievalAssessment.Models;
using SievalAssessment.Repositories;

namespace SievalAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsRepository _repository;

        public ProductsController(ILogger<ProductsController> logger, IProductsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_repository.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var result = _repository.GetProduct(id);
            return result != null ? Ok(result) : NotFound();            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _repository.DeleteProduct(id) ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, ProductDTO productInput)
        {
            return _repository.UpdateProduct(id, productInput) ? Ok() : NotFound();
        }

        [HttpPost]
        public ActionResult Add(ProductDTO productInput)
        {
            _repository.AddProduct(productInput);

            return Ok();
        }
    }
}