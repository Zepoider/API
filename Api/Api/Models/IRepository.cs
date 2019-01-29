using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
    interface IRepository
    {

        List <object> All();

        void Insert(object obj);

        void Delete(Guid id);

        object Get(Guid id);

        void Update(Guid id);
   
    }
}
