using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    class OrderItem
    {
        Guid OrderId;

        Guid OrderItemId;
        Product Item { get; set; }
        int quantity { get; set; }
        double price { get; set; }


        OrderItem ()
        {
            Item = new Product();
            OrderItemId = Guid.NewGuid();
            price = Item.CurrentPrice * quantity;
        }
        
    }
}
