using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    public enum Preferences
    {
        Neutral,
        FirstTeam,
        SecondTeam
    }
    public class Refery
    {
        public string Name { get; set; }
        public Preferences Pref { get; set; }
        public Refery(string _name)
        {
            Pref = Preferences.Neutral;
            Name = _name;
        }
        public Refery(string _name, Preferences _pref)
        {
            Pref = _pref;
            Name = _name;
        }
    }
}
