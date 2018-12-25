using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class Address : EntityBase
    {
        public Address()
        {
        }
        public Address(int addressId)
        {
            base.Id = addressId;
        }
        public int AddressType;
        public string StreetLine1;
        public string StreetLine2;
        public string City;
        public string State;
        public string PostalCode;
        public string Country;
        public new void DisplayEntityInfo()
        {
            Console.WriteLine($"Address Id - {base.Id}, country - {this.Country}, city - {this.City}");
        }
    }
}
