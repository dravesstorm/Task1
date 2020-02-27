using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task1.Models;
using Task1.Exceptions;

namespace Task1.Services
{
    public class GameService
    {
        Game _game;

        public GameService(Game game)
        {
            _game = game;
        }

        public void ShowResult()
        {
            if (Math.Abs(_game.First.TeamSkill - _game.Second.TeamSkill) <
            ((_game.First.TeamSkill + _game.Second.TeamSkill) / 2) * 0.10)
                Console.WriteLine("Ничья!");
            else
            {
                if (_game.First.TeamSkill > _game.Second.TeamSkill) Console.WriteLine($"{_game.First.Name} победила!");
                else Console.WriteLine($"{_game.Second.Name} победила!");
            }
        }

        public delegate void GoalHandler(Team scored);
        public event GoalHandler eGoal;
        public delegate void FoulHandler(Team scored);
        public event FoulHandler eFoul;


        public void Goal(Team scored)
        {
            eGoal?.Invoke(scored);
        }

        public void Foul(Team scored)
        {
            eFoul?.Invoke(scored);
        }

        public void Start()
        {
            Console.WriteLine($"Игра {_game.First.Name} VS {_game.Second.Name} началась!");
            try
            {
                Random rand = new Random();
                int idExpt = rand.Next(0, 5);
                switch (idExpt)
                {
                    case 0: Console.WriteLine("Игра прошла нормально :з"); break;
                    case 1: throw new WeatherException("Землетрясение", 10);
                    case 2: throw new FanException(21);
                    case 3: throw new DiseaseException(75);
                    case 4: throw new WeatherException("Дождь", 20);
                    default: break;
                }
            }            
            catch (WeatherException wex)
            {
                Console.WriteLine($"Началось: {wex.Message} и длилось {wex.Value} минут");
            }
            catch (FanException fex)
            {
                Console.WriteLine($"Фанат {fex.Age} выбежал на поле");
            }
            catch (DiseaseException dex)
            {
                Console.WriteLine($"Игрок под номером {dex.Value} получил травму");
            }

        }

    }
    
}
