using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    public class Game
    {
        private Team _first;
        private Team _second;
        public Refery _refery;
        public Team First => _first;
        public Team Second => _first;
        public int[] goalCount = new int[2];
        public Game( Team first,  Team second, Refery refery)
        {
            try
            {
                if (first.team.Count < 11 || first.team.Count < 11) throw new Exception("Неполный состав команд");
                _first = first;
                _second = second;
                _refery = refery;
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
