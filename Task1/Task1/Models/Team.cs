﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    class Team
    {
        public string Name { get; set; }
        public List<Footballer> team = new List<Footballer>();
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
