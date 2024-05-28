namespace MyBeerShop.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal FinalPrice { get; set; }
        public string CustomerId { get; set; } = null!;
        public Customer Customer { get; set; } = null!;

    }
}
