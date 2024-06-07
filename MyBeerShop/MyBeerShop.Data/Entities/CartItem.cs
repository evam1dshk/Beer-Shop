using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeerShop.Data.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        public int Quantity { get; set; }
    }
}
