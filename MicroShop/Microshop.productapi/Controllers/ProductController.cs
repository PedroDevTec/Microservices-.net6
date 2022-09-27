using Microshop.productapi.Data.ValueObjects;
using Microshop.productapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microshop.productapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ??
             throw new ArgumentNullException(nameof(repository));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll(long id)
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindById(ProductVO vo)
        {
           if (vo == null) return BadRequest();
           var products = await _repository.Create(vo);
           return Ok(products);
        }
        [HttpPut]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Update(ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var products = await _repository.Update(vo);
            return Ok(products);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

    }
}
