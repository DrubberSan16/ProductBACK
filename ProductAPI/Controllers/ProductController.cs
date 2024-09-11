using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data.UnitOfWork;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProducts([FromQuery] string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return BadRequest("El término de búsqueda no puede estar vacío.");
            }

            // Filtrar productos usando el término de búsqueda
            var products = await _unitOfWork.Products.FindAsync(p => p.NameProduct.Contains(search) || p.Description.Contains(search));

            if (products == null || !products.Any())
            {
                return NotFound("No se encontraron productos que coincidan con el término de búsqueda.");
            }

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Products.Update(product);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ((await _unitOfWork.Products.GetByIdAsync(id)) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }

}
