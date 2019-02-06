using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace Api
{
    public class EntityRepositoryJSON<T> : IRepository<T> where T : EntityBase
    {

        public EntityRepository<T> repo;

        public EntityRepositoryJSON()
        {
            repo = new EntityRepository<T>();
        }

        void Serialize(string fileName)
        {

            var entities = JsonConvert.SerializeObject(repo._entities, Formatting.Indented);

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + fileName;

            using (File.Open(path, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
            }

            using (StreamWriter stream = new StreamWriter(path, true))
            {
                stream.WriteLine(entities);
            }
        }
        public List<T> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            repo.Delete(id);
            Serialize(CheckObject());
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            repo.Insert(obj);
            Serialize(CheckObject());
        }

        public void Update(Guid id, T obj)
        {
            repo.Update(id, obj);
            Serialize(CheckObject());
        }

        public string CheckObject()
        {

            string fileName = "junk.json";
            string name = typeof(T).Name;

            if (name == "Customer")
            {
                fileName = "customer.json";
            }
            else
            if (name == "Order")
            {
                fileName = "order.json";
            }
            else
            if (name == "OrderItem")
            {
                fileName = "orderItem.json";
            }
            else
            if (name == "Product")
            {
                fileName = "product.json";
            }

            return fileName;
        }
    }
}
