using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Box<T>
    {
        private readonly T value;

        public Box(T item)
        {
            value = item;
        }

        public override string ToString()
        {
            return $"{value.GetType()}: {value}";
        }

    }
}
