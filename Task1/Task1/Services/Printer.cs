using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task1.Services
{
    public interface IWriter
    {
        void Write(string str);
        void WriteLine(string str);
        void WriteLine();
    }

    public class ConsoleWriter : IWriter
    {
        public void Write(string str)
        {
            Console.Write(str);
        }
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
        public void WriteLine()
        {
            Console.WriteLine();
        }
    }

    public class FileWriter : IWriter
    {
        public StreamWriter sw { get; set; }

        public void Write(string str)
        {
            sw.Write(str);
        }
        public void WriteLine(string str)
        {
            sw.WriteLine(str);
        }
        public void WriteLine()
        {
            sw.WriteLine();
        }
    }
}

