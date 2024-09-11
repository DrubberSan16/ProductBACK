using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data.Repositories;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly WishlistRepository _wishlistRepository;

        public WishlistController(WishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }

        // Obtener productos deseados filtrados por UUID de sesión de usuario
        [HttpGet("{sessionUuid}")]
        public async Task<IActionResult> GetWishlistBySessionUuid(string sessionUuid)
        {
            var wishlist = await _wishlistRepository.GetWishlistBySessionUuidAsync(sessionUuid);
            return Ok(wishlist);
        }

        // Agregar un producto a la lista de deseados
        [HttpPost]
        public async Task<IActionResult> AddToWishlist([FromBody] AddWishlistRequest request)
        {
            await _wishlistRepository.AddToWishlistAsync(request.ProductId, request.SessionUuid);
            return Ok();
        }

        // Eliminar un producto de la lista de deseados
        [HttpDelete]
        public async Task<IActionResult> RemoveFromWishlist([FromQuery] string productId, [FromQuery] string sessionUuid)
        {
            await _wishlistRepository.RemoveFromWishlistAsync(productId, sessionUuid);
            return Ok();
        }
    }

}
