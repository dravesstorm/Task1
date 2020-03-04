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
        private IWriter writer;

        public TeamService(Team _MyTeam, IWriter writer)
        {
            MyTeam = _MyTeam;
            this.writer = writer;
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
                writer.WriteLine($"Ошибка: {e.Message}");
            }
        }

        public void Show()
        {
            writer.WriteLine($"{this.MyTeam.Name}");
            var result = from fb in MyTeam.team
                         orderby fb.Name
                         select fb;

            foreach (Footballer fb in result)
            {
                writer.Write($"Name: {fb.Name}".PadRight(25));
                writer.Write($"Age: {fb.Age}\t\t");
                writer.Write($"Skill: {fb.SkillLevel}\n");
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
                writer.Write($"Name: {fb.Name}".PadRight(25));
                writer.Write($"Age: {fb.Age}\t\t");
                writer.Write($"Skill: {fb.SkillLevel}\n");
            }
        }

        public void ShowTrainer()
        {
            writer.WriteLine("Тренер: ");
            writer.Write($"Name: {this.MyTeam.trainer.Name}".PadRight(25));
            writer.Write($"Luck: {this.MyTeam.trainer.LuckLevel}");
        }


        void SetSkillLevel()
        {
            int[] levels = MyTeam.team.Select(fb => fb.SkillLevel).ToArray();
            for (int i = 0; i < levels.Length; i++)
            {
                MyTeam.TeamSkillLevel += levels[i];
            }
            MyTeam.TeamSkillLevel *= MyTeam.trainer.LuckLevel;
        }
    }
}
