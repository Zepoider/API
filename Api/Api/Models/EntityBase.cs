using System;
using System.Collections.Generic;
using System.Text;

namespace Api
{
   public abstract class EntityBase
    {
        public Guid Id;

        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual void DisplayEntityInfo()
        {
        
        }

        public abstract bool Validate();
        
    }
}
