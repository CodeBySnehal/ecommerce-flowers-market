using EcommerceShoppingCartASPNET8.Models;

namespace EcommerceShoppingCartASPNET8.Services
{
    public interface ICartService
    {
        void AddItem(Product product, int quantity);

        void RemoveItem(string productId);

        void ClearCart();

        Cart GetCart();
    }
}
