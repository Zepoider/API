using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class Product : EntityBase
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }

        public Product(string Name, double Price)
        {
            Id = Guid.NewGuid();
            ProductName = Name;
            CurrentPrice = Price;
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }

        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"Product {ProductName} Price: {CurrentPrice}");
        }
    }
}
