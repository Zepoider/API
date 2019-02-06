using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class Order : EntityBase
    {
        public Customer Customer { get; set; }
        DateTime OrderDate { get; set; }
        string ShippingAddress { get; set; }

        List <Guid>  OrderItems;



        public Order()
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.UtcNow;
        }

        public Order(Customer customer)
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.UtcNow;
            Customer = customer;
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Order {Id}");
        }
    }
}
