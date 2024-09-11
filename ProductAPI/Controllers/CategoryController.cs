using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;
using ProductAPI.Data.UnitOfWork;

namespace CategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categorys = await _unitOfWork.Categories.GetAllAsync();
            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(long id)
        {
            var Category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            return Ok(Category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Categories.Update(category);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ((await _unitOfWork.Categories.GetByIdAsync(id)) == null)
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
        public async Task<IActionResult> DeleteCategory(long id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
