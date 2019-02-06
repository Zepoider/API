using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class Customer : EntityBase
    {
        public List<Address> AddressList { get; set; }
        public string FirstName { get; set; }
        public int CustomerType { get; set; }
        public static int InstanceCount { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get => FirstName + " " + LastName; }


        public Customer (string first, string last)
        {
            Id = Guid.NewGuid();
            FirstName = first;
            LastName = last;
        }


        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"User {FullName}");
        }

        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(FirstName)) isValid = false;
            return isValid;
        }
    }
}
