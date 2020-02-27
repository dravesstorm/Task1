using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Exceptions
{
    public class FanException : Exception
    {
        public int Age { get; }
        public FanException(int age) : base()
        {
            Age = age;
        }
    }
}
