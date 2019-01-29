using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api
{
    public class EntityRepository : IRepository
    {
        public Dictionary<Guid, Customer> _customers = new Dictionary<Guid, Customer>();
        //public Dictionary<Guid, Address> _addresses = new Dictionary<Guid, Address>();
        public Dictionary<Guid, Order> _orders = new Dictionary<Guid, Order>();

        Logger logger;

        public EntityRepository()
        {
            logger = new Logger();
        }

        public List<object> All()
        {
            return null;
        }

        public List<Customer> All(Customer custmer)
        {
            return _customers.Values.ToList();
        }

        public List<Order> All(Order order)
        {
            return _orders.Values.ToList();
        }

        //If user don't exist, insert him to dictionary. Otherwice, send error message
        public void Insert(object attrib)
        {
            if (attrib is Customer)
            {
                Customer obj = (Customer)attrib;

                if (!_customers.ContainsKey(obj.Id))
                {
                    _customers.Add(obj.Id, obj);
                    logger.LogInfo($"Customer {obj.Id} added");
                }
                else
                {
                    logger.ErrorInfo($"Customer {obj.Id} is already exist");
                }

                return;
            }

            if (attrib is Order)
            {
                Order obj = (Order)attrib;

                if (!_orders.ContainsKey(obj.OrderId))
                {
                    _orders.Add(obj.OrderId, obj);
                    logger.LogInfo($"Order {obj.OrderId} added");
                }
                else
                {
                    logger.ErrorInfo($"Order {obj.OrderId} is already exist");
                }

                return;
            }
        }

        //Take user ID, and remove object with that ID from dictionary
        public void Delete(Guid id)
        {

            object attrib = Get(id);

            if (attrib is Customer)
            {
            //If object = custmer, remove object and all orders that customer
                if (_customers.ContainsKey(id))
                {

                    Order deleteOrder = new Order();
                    var orderArray = All(deleteOrder);

                    for (int i = 0; i < _orders.Count; i++)
                    {
                        Customer customer = (Customer)attrib;

                        if (orderArray[i].Customer.Id == customer.Id)
                        {
                            _orders.Remove(orderArray[i].OrderId);
                            logger.LogInfo($"Order {orderArray[i].OrderId} removed");
                        }
                    }

                    _customers.Remove(id);
                    logger.LogInfo($"Customer {id} removed");
                }
                else
                {
                    logger.ErrorInfo($"Customer {id} dosn't exist");
                }
            }

            if (attrib is Order)
            {
                if (_orders.ContainsKey(id))
                {
                    _orders.Remove(id);
                    logger.LogInfo($"Order {id} removed");
                }
                else
                {
                    logger.ErrorInfo($"Order {id} dosn't exist");
                }
            }
        }

        //Check dictionary for ID, if don't find, send error message 
        public object Get(Guid id)
        {
            object obj = null;

            if (_customers.ContainsKey(id))
            {
                Customer _customer = new Customer();
                _customers.TryGetValue(id, out _customer);
                return (object)_customer;
            }

            if (_orders.ContainsKey(id))
            {
                Order _order = new Order();
                _orders.TryGetValue(id, out _order); ;
                return (object)_order;
            }

            return obj;
        }

        //Update exist object
        public void Update(Guid id)
        {
            var attrib = Get(id);

            if (attrib != null)
            {
                if (attrib is Customer)
                {
                    _customers.Remove(id);
                    Insert(attrib);
                    logger.LogInfo($"Customer {id} updated");
                }

                if (attrib is Order)
                {
                    _orders.Remove(id);
                    Insert(attrib);
                    logger.LogInfo($"Order {id} updated");
                }
            }

        }
    }
}
