using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
