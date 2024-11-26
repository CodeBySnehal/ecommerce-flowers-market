
using EcommerceShoppingCartASPNET8.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceShoppingCartASPNET8.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        { 
        
        }
    }


}
