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

        Random rnd = new Random();
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

        public void ShowGoalCount()
        {
            Console.WriteLine(_game.goalCount[0] + " : " + _game.goalCount[1]);
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
            Console.WriteLine($"Рефери {_game._refery.Name} подсуживает команде {_game._refery.pref}");
            try
            {   //генерация случайного исключения
                Random rand = new Random();
                int idExсpt = rand.Next(0, 5);
                switch (idExсpt)
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
                Console.WriteLine($"Фанат {fex.Age} лет выбежал на поле");
            }
            catch (DiseaseException dex)
            {
                Console.WriteLine($"Игрок под номером {dex.Value} получил травму");
            }

        }

        public void NoticeGoal(Team scored) //передаётся команда забившая гол
        {
            Console.WriteLine($"Команда {scored.Name} забила гол!");
            if (_game._refery.pref == Preferences.neutral)
            {
                if (scored == _game.First)
                    _game.goalCount[0]++;
                else
                {
                    if (scored == _game.Second)
                        _game.goalCount[1]++;
                }
            }
            else
            {
                if (_game._refery.pref == Preferences.firstTeam)
                {
                    if (scored == _game.First)
                    {
                        _game.goalCount[0]++;
                    }

                    else
                    {
                        if (scored == _game.Second && rnd.Next(0, 100) > 50)
                        {
                            _game.goalCount[1]++;
                            Console.WriteLine("Гол засчитан");
                        }
                        else Console.WriteLine("Но гол не засчитан");
                    }

                }
                else
                {
                    if (scored == _game.Second)
                        _game.goalCount[1]++;
                    else
                    {
                        if (scored == _game.First && rnd.Next(0, 100) > 50)
                        {
                            _game.goalCount[0]++;
                            Console.WriteLine("Но гол засчитан");
                        }
                        else Console.WriteLine("Гол не засчитан");
                    }
                }
            }
        }

        public void NoticeFoul(Team scored) //передаётся команда нарушившая  правила
        {
            Console.WriteLine($"Команда {scored.Name} нарушила правила!");
        }

    }

}
