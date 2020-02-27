using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Exceptions
{
    class DiseaseException : Exception
    {

        public int Value { get; }
        public DiseaseException(int val) : base()
        {
            Value = val;

        }
    }
}
