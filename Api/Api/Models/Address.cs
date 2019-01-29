using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class Address : EntityBase
    {
        
        public int AddressType { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public override void DisplayEntityInfo()
        {
            
        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
