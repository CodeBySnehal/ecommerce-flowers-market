namespace EcommerceShoppingCartASPNET8.Models
{
    public class Cart
    {
        public string Id { get; set; }

        public List<Item> Items { get; set; }

        public double TotalCost => Items.Sum(item => item.Cost);
        public Cart()
        {
        Items = new List<Item>();
        }


    }
}
