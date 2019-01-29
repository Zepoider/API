using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class Order : EntityBase
    {
        public Customer Customer { get; set; }
        public Guid OrderId { get; set; }
        DateTime OrderDate { get; set; }
        string ShippingAddress { get; set; }

        List <Guid>  OrderItems;

        public Order()
        {
            OrderId = Guid.NewGuid();
            OrderDate = DateTime.UtcNow;
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"User {Customer.Id} Order {OrderId}");
        }
    }
}
