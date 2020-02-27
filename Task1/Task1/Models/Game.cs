using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1.Models
{
    class Game
    {
        public Team _first;
        public Team _second;
        public Refery refery;
        public Team First => _first;
        public Team Second => _first;
        public  int[] goalCount = new int[2];
        public Game(Team first, Team second, Refery _refery)
        {
            try
            {
                if (_first.team.Count < 11 || _second.team.Count < 11) throw new Exception("Неполный состав команд");
                _first = first;
                _second = second;
                _refery = refery;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }


    }
}
