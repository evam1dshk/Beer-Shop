using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeerShop.Data.Enums
{
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Shipped,
        Paid,
        Delivered,
        Cancelled
    }
}
