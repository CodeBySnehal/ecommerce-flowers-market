using EcommerceShoppingCartASPNET8.Data;
using EcommerceShoppingCartASPNET8.Models;
using EcommerceShoppingCartASPNET8.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceShoppingCartASPNET8.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly ProductContext _productContext;

        public CartController(CartService cartService, ProductContext productContext)
        { 
            _cartService = cartService;
            _productContext = productContext;

        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        public IActionResult AddToCart([FromBody] AddToCartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cart = _cartService.GetCart();

                // Check if the product already exists in the cart
                var existingItem = cart.Items.FirstOrDefault(item => item.Product.Id == model.ProductId);
                if (existingItem != null)
                {
                    // Update the quantity of the existing item
                    existingItem.Quantity = model.Quantity;
                    _cartService.UpdateCart(cart);

                    // Return a JSON response with the updated flag
                    return Json(new { updated = true });
                }

                // The product is not in the cart, add it
                _cartService.AddToCart(model.ProductId, model.Quantity);
                _cartService.UpdateCart(cart);

                // Return a JSON response with the updated flag set to false
                return Json(new { updated = false });
            }

            // Model validation failed, return a BadRequest response
            return BadRequest();
        }

        public IActionResult Remove(string productid)
            {
                _cartService.RemoveItem(productid);
                return RedirectToAction("Index", "Cart");
            }
    }

}
