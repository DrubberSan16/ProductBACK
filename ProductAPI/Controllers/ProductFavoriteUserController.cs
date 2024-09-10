using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data.UnitOfWork;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFavoriteUsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductFavoriteUsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductFavoriteUser>>> GetProductFavoriteUsers()
        {
            var productFavoriteUsers = await _unitOfWork.ProductFavoriteUsers.GetAllAsync();
            return Ok(productFavoriteUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductFavoriteUser>> GetProductFavoriteUser(int id)
        {
            var productFavoriteUser = await _unitOfWork.ProductFavoriteUsers.GetByIdAsync(id);

            if (productFavoriteUser == null)
            {
                return NotFound();
            }

            return Ok(productFavoriteUser);
        }

        [HttpPost]
        public async Task<ActionResult<ProductFavoriteUser>> PostProductFavoriteUser(ProductFavoriteUser productFavoriteUser)
        {
            await _unitOfWork.ProductFavoriteUsers.AddAsync(productFavoriteUser);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetProductFavoriteUser", new { id = productFavoriteUser.Id }, productFavoriteUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductFavoriteUser(int id, ProductFavoriteUser productFavoriteUser)
        {
            if (id != productFavoriteUser.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ProductFavoriteUsers.Update(productFavoriteUser);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ((await _unitOfWork.ProductFavoriteUsers.GetByIdAsync(id)) == null)
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
        public async Task<IActionResult> DeleteProductFavoriteUser(int id)
        {
            var productFavoriteUser = await _unitOfWork.ProductFavoriteUsers.GetByIdAsync(id);
            if (productFavoriteUser == null)
            {
                return NotFound();
            }

            _unitOfWork.ProductFavoriteUsers.Delete(productFavoriteUser);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }

}
