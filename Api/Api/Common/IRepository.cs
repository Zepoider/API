using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    interface IRepository <T> 
    {

        List <T> All();

        void Insert(T obj);

        void Delete(Guid id);

        T Get(Guid id);

        void Update(Guid id, T obj);
   
    }
}
