using System;

namespace Api
{
    class Program
    {
        static void Main(string[] args)
        {

            EntityRepository repo = new EntityRepository();
            EntityRepositoryJSON repoJson = new EntityRepositoryJSON();
            repoJson.repo = repo;

            for (int i = 0; i < 4; i++)
            {
                Customer customer = new Customer();
                repoJson.Insert(customer);
                Order order = new Order();
                order.Customer = customer;
                repoJson.Insert(order);
                Order order1 = new Order();
                order1.Customer = customer;
                repoJson.Insert(order1);
            }

            foreach (var item in repo._customers)
            {
                item.Value.DisplayEntityInfo();
            }

            Console.WriteLine("_______ All Orders _________________");

            foreach (var item in repo._orders)
            {
                item.Value.DisplayEntityInfo();
            }

            Console.WriteLine("_______ All Customers and Orders after delete_________________");

            var customerArray = repo.All(new Customer());
            
            repoJson.Delete(customerArray[0].Id);
            repoJson.Delete(customerArray[1].Id);

            foreach (var item in repo._customers)
            {
                item.Value.DisplayEntityInfo();

                foreach (var item1 in repo._orders)
                {
                    if (item1.Value.Customer.Id == item.Value.Id)
                    {
                        item1.Value.DisplayEntityInfo();
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
