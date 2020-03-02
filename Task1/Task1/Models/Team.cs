using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task1.Structures;

namespace Task1.Models
{
    public class Team
    {
        public string Name { get; set; }
        public MyList<Footballer> team = new MyList<Footballer>();
        public double TeamSkillLevel = 0;
        public double TeamSkill => TeamSkillLevel;
        public Trainer trainer;

        public Team(string _name, Trainer _trainer)
        {
            Name = _name;
            trainer = _trainer;
        }        
    }
}
