using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    public class Game
    {
        private Team first;
        private Team second;
        public Refery Refery;
        public Team First => first;
        public Team Second => second ;
        public int[] goalCount = new int[2];

        public Game( Team first,  Team second, Refery refery)
        {
            try
            {
                if (first.team.Count < 11 || second.team.Count < 11) throw new Exception("Неполный состав команд");
                this.first = first;
                this.second = second;
                Refery = refery;
                goalCount[0] = 0;
                goalCount[1] = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }


    }
}
