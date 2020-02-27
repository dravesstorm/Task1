using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Exceptions
{
    class WeatherException : Exception
    {
        public int Value { get; }
        public WeatherException(string message, int val) : base(message)
        {
            Value = val;
        }
    }
}

