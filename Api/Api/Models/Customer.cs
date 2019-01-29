using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    public class Customer : EntityBase
    {

        public List<Address> AddressList;
        public string FirstName { get; set; }
        public int CustomerType { get; set; }
        public static int InstanceCount { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get => FirstName + " " + LastName; }


        public Customer (): base()
        {

        }
        


        public override void DisplayEntityInfo()
        {
            Console.WriteLine($"User {Id}");
        }

        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(EmailAddress)) isValid = false;
            return isValid;
        }
    }
}
