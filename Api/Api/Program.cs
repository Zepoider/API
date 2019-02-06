using System;

namespace Api
{
    class Program
    {
        static void Main(string[] args)
        {

            EntityRepositoryJSON<Customer> repoJsonCustomer = new EntityRepositoryJSON<Customer>();
            EntityRepositoryJSON<Order> repoJsonOrder = new EntityRepositoryJSON<Order>();
            EntityRepositoryJSON<OrderItem> repoJsonOrderItem = new EntityRepositoryJSON<OrderItem>();
            EntityRepositoryJSON<Product> repoJsonProduct = new EntityRepositoryJSON<Product>();

            Product spaceship = new Product("Interstellar Spaceship", 5000000);
            repoJsonProduct.Insert(spaceship); 
            Product tank = new Product("Hover Tank", 10000);
            repoJsonProduct.Insert(tank);


            Customer customer = new Customer("Alex", "Burn");
            repoJsonCustomer.Insert(customer);

            Order order = new Order(customer);
            repoJsonOrder.Insert(order);

            OrderItem item = new OrderItem(spaceship, order.Id, 2);
            repoJsonOrderItem.Insert(item);
            OrderItem item2 = new OrderItem(tank, order.Id, 10);
            repoJsonOrderItem.Insert(item2);

            Order order1 = new Order(customer);
            repoJsonOrder.Insert(order1);

            OrderItem item3 = new OrderItem(tank, order1.Id, 15);
            repoJsonOrderItem.Insert(item3);



            foreach (var obj in repoJsonCustomer.repo._entities)
            {
                obj.Value.DisplayEntityInfo();

                foreach (var obj1 in repoJsonOrder.repo._entities)
                {
                    if (obj1.Value.Customer.Id == obj.Value.Id)
                    {
                        obj1.Value.DisplayEntityInfo();

                        foreach (var obj2 in repoJsonOrderItem.repo._entities)
                        {
                            if (obj2.Value.OrderId == obj1.Value.Id)
                            {
                                obj2.Value.DisplayEntityInfo();

                                foreach (var obj3 in repoJsonProduct.repo._entities)
                                {
                                    if (obj3.Value.Id == obj2.Value.Item.Id)
                                    {
                                        obj3.Value.DisplayEntityInfo();
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }

            Console.ReadKey();
        }
    }
}
