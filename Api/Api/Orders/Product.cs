using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    class Product
    {
        Guid ProductId;
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }
        
    }
}
