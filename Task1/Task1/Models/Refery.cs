using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    enum Preferences
    {
        neutral,
        firstTeam,
        secondTeam
    }
    class Refery
    {
        public string Name { get; set; }
        Preferences pref = Preferences.neutral;
        public Refery(string _Name)
        {
            Name = _Name;
        }

        public void NoticeGoal(Team scored) //передаётся команда забившая гол
        {
            Console.WriteLine($"Команда {scored.Name} забила гол!");
        }

        public void NoticeFoul(Team scored) //передаётся команда нарушившая  правила
        {
            Console.WriteLine($"Команда {scored.Name} нарушила правила!");
        }

    }
}
