using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api
{
    public class EntityRepository <T> : IRepository <T> where T : EntityBase
    {
        public Dictionary<Guid, T> _entities = new Dictionary<Guid, T>();

        Logger logger;

        public EntityRepository()
        {
            logger = new Logger();
        }

        public List<T> All()
        {
            return _entities.Values.ToList<T>();
        }


        //If user don't exist, insert him to dictionary. Otherwice, send error message
        public void Insert(T attrib)
        {

                if (!_entities.ContainsKey(attrib.Id))
                {
                    _entities.Add(attrib.Id, attrib);
                    logger.LogInfo($"Order {attrib.Id} added");
                }
                else
                {
                    logger.ErrorInfo($"Order {attrib.Id} is already exist");
                }

           
        }

        //Take user ID, and remove object with that ID from dictionary
        public void Delete(Guid id)
        {

            T attrib = Get(id);
           
                if (_entities.ContainsKey(id))
                {
                    _entities.Remove(id);
                    logger.LogInfo($"Order {id} removed");
                }
                else
                {
                    logger.ErrorInfo($"Order {id} dosn't exist");
                }
            
        }

        //Check dictionary for ID, if don't find, send error message 
        public T Get(Guid id)
        {
            T obj = null;

            if (_entities.ContainsKey(id))
            {
                _entities.TryGetValue(id, out obj);
            }

            return obj;
        }

        //Update exist object
        public void Update(Guid id, T obj)
        {
            var attrib = Get(id);

            if (attrib != null)
            {
                    _entities.Remove(id);
                    Insert(obj);
                    logger.LogInfo($"Customer {id} updated");
            }

        }
    }
}
