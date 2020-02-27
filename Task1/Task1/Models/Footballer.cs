using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    class Footballer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int skillLevel;
        public int SkillLevel => skillLevel;
        Random rnd = new Random();

        public Footballer(string _Name, int _Age)
        {
            Name = _Name;
            Age = _Age;
            skillLevel = rnd.Next(0, 100);
        }
    }
}
