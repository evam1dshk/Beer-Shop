namespace MyBeerShop.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

    }
}
