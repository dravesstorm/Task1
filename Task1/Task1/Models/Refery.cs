using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    public enum Preferences
    {
        neutral,
        firstTeam,
        secondTeam
    }
    public class Refery
    {
        public string Name { get; set; }
        public Preferences pref { get; set; }        
        public Refery(string _Name)
        {
            pref = Preferences.neutral;
            Name = _Name;
        }
        public Refery(string _Name, Preferences _pref)
        {
            pref = _pref;
            Name = _Name;
        }

    }
}
