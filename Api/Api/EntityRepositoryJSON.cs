using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace Api
{
    public class EntityRepositoryJSON : IRepository
    {

        public EntityRepository repo;

        public EntityRepositoryJSON()
        {
            
        }



        void Serialize()
        {
            DataContractJsonSerializer customer = new DataContractJsonSerializer(typeof(Dictionary<Guid, Customer>));
            DataContractJsonSerializer order = new DataContractJsonSerializer(typeof(Dictionary<Guid, Order>));

            FileStream streamCustomer = new FileStream("customer.json", FileMode.Create);
            customer.WriteObject(streamCustomer, repo._customers);
            streamCustomer.Close();

            FileStream streamOrder = new FileStream("order.json", FileMode.Create);
            order.WriteObject(streamOrder, repo._orders);
            streamOrder.Close();
        }
        public List<object> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            repo.Delete(id);
            Serialize();
        }

        public object Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(object obj)
        {
            repo.Insert(obj);
            Serialize();
        }

        public void Update(Guid id)
        {
            repo.Update(id);
            Serialize();
        }
    }
}
