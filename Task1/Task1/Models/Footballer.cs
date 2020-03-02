using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    public class Footballer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int skillLevel;
        public int SkillLevel => skillLevel;

        static Random rnd = new Random();

        public Footballer(string _name, int _age)
        {

            Name = _name;
            Age = _age;
            skillLevel = rnd.Next(0, 100);

        }
    }
}
