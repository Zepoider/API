using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    class Cell<T>
    {
        public T data;
        public Cell<T> next;
        public Cell<T> previous;
        public int index;

        public Cell()
        {
        }

        public Cell(T data)
        {
            this.data = data;
        }
    }
}
