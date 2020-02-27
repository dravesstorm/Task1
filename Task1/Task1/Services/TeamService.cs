using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task1.Models;

namespace Task1.Services
{
    class TeamService
    {

        public Team MyTeam;

        public TeamService(Team _MyTeam)
        {
            MyTeam = _MyTeam;
        }

        public void Add(Footballer fb)
        {
            try
            {
                if (MyTeam.team.Count >= 11) throw new Exception("В основной состав нельзя добавить более 11 игроков");
                else
                {
                    MyTeam.team.Add(fb);
                    SetSkillLevel();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
        public void Remove(string name)
        {
            int poka = MyTeam.team.FindIndex(x => x.Name.Contains(name));
            MyTeam.team.RemoveAt(poka + 1);
            SetSkillLevel();
        }

        public void RemoveWeakest()
        {
            int min = MyTeam.team[0].SkillLevel;
            int poka = 0;
            for (int i = 0; i < MyTeam.team.Count; i++)
            {
                if (MyTeam.team[i].SkillLevel < min)
                {
                    min = MyTeam.team[i].SkillLevel;
                    poka = i;
                }
            }
            MyTeam.team.RemoveAt(poka);
            SetSkillLevel();
        }

        public void Show()
        {
            Console.WriteLine($"{this.MyTeam.Name}");
            var result = from fb in MyTeam.team
                         orderby fb.Name
                         select fb;

            foreach (Footballer fb in result)
            {
                Console.Write($"Name: {fb.Name}".PadRight(25));
                Console.Write($"Age: {fb.Age}\t\t");
                Console.Write($"Skill: {fb.SkillLevel}");
                Console.WriteLine();
            }
        }

        public void ShowSenior()
        {
            var result = from fb in MyTeam.team
                         where fb.Age >= 30
                         orderby fb.SkillLevel descending
                         select fb;
            foreach (Footballer fb in result)
            {
                Console.Write($"Name: {fb.Name}".PadRight(25));
                Console.Write($"Age: {fb.Age}\t\t");
                Console.Write($"Skill: {fb.SkillLevel}");
                Console.WriteLine();
            }
        }

        public void ShowTrainer()
        {
            Console.WriteLine("Тренер: ");
            Console.Write($"Name: {this.MyTeam.trainer.Name}".PadRight(25));
            Console.Write($"Luck: {this.MyTeam.trainer.LuckLevel}");
        }


        void SetSkillLevel()
        {
            MyTeam.TeamSkillLevel = 0;
            for (int i = 0; i < MyTeam.team.Count; i++)
            {
                MyTeam.TeamSkillLevel += MyTeam.team[i].SkillLevel;
            }
            MyTeam.TeamSkillLevel *= MyTeam.trainer.LuckLevel;
        }

    }
}
