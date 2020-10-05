using System;
using System.Collections.Generic;
using System.Text;

namespace SportStore.Domain.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
