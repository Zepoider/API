using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class OrderItem : EntityBase
    {
        public Guid OrderId { get; set; }
        public Product Item { get; set; }
        public int Quantity { get; set; }
        public double price { get => Item.CurrentPrice * Quantity; }


        public OrderItem ()
        {
            Id = Guid.NewGuid();
        }

        public OrderItem(Product prod, Guid orderid, int quantity)
        {
            Id = Guid.NewGuid();
            Item = prod;
            OrderId = orderid;
            Quantity = quantity;
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Item: {Item.ProductName} Quantity: {Quantity} Summary price: {price}");
        }
    }
}
