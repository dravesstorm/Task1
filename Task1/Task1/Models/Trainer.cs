using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    public class Trainer
    {
        public string Name { get; set; }
        double luckLevel;
        public double LuckLevel => luckLevel;
        Random rnd = new Random();

        public Trainer(string _Name)
        {
            Name = _Name;
            luckLevel = rnd.NextDouble() * (1.5 - 0.5) + 0.5;
        }
    }
}
