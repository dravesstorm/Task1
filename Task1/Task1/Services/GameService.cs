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
        Game game;
        IWriter writer;

        public delegate void GoalHandler(Team scored);
        public event GoalHandler eGoal;
        public delegate void FoulHandler(Team scored);
        public event FoulHandler eFoul = (x) => { };

        Random rnd = new Random();

        public GameService(Game game, IWriter writer)
        {
            this.game = game;
            this.writer = writer;
        }

        public void ShowResult()
        {
            if (Math.Abs(game.First.TeamSkill - game.Second.TeamSkill) <
            ((game.First.TeamSkill + game.Second.TeamSkill) / 2) * 0.10)
                writer.WriteLine("Ничья!");
            else
            {
                if (game.First.TeamSkill > game.Second.TeamSkill) writer.WriteLine($"{game.First.Name} победила!");
                else writer.WriteLine($"{game.Second.Name} победила!");
            }
        }

        public void ShowGoalCount()
        {
            writer.WriteLine(game.goalCount[0] + " : " + game.goalCount[1]);
        }



        public void Goal(Team scored, Footballer hero)
        {
            eGoal.Invoke(scored);
        }

        public void Foul(Team scored)
        {
            eFoul.Invoke(scored);
        }

        public void Start()
        {
            writer.WriteLine($"Игра {game.First.Name} VS {game.Second.Name} началась!");
            writer.WriteLine($"Рефери {game.Refery.Name} подсуживает команде {game.Refery.Pref}");
            try
            {   //генерация случайного исключения
                Random rand = new Random();
                int idExсpt = rand.Next(0, 10000000);
                idExсpt %= 5;
                switch (idExсpt)
                {
                    case 0: writer.WriteLine("Игра прошла нормально :з"); break;
                    case 1: throw new WeatherException("Землетрясение", 10);
                    case 2: throw new FanException(21);
                    case 3: throw new DiseaseException(75);
                    case 4: throw new WeatherException("Дождь", 20);
                    default: break;
                }
            }
            catch (WeatherException wex)
            {
                writer.WriteLine($"Началось: {wex.Message} и длилось {wex.Value} минут");
            }
            catch (FanException fex)
            {
                writer.WriteLine($"Фанат {fex.Age} лет выбежал на поле");
            }
            catch (DiseaseException dex)
            {
                writer.WriteLine($"Игрок под номером {dex.Value} получил травму");
            }

        }

        public void NoticeGoal(Team scored) //передаётся команда забившая гол
        {
            writer.WriteLine($"Команда {scored.Name} забила гол!");



            if (game.Refery.Pref == Preferences.Neutral)
            {
                if (scored == game.First)
                    game.goalCount[0]++;
                else
                {
                    if (scored == game.Second)
                        game.goalCount[1]++;
                }
            }
            else
            {
                if (game.Refery.Pref == Preferences.FirstTeam)
                {
                    if (scored == game.First)
                    {
                        game.goalCount[0]++;
                    }

                    else
                    {
                        if (scored == game.Second && rnd.Next(0, 100) > 50)
                        {
                            game.goalCount[1]++;
                            writer.WriteLine("Гол засчитан");
                        }
                        else writer.WriteLine("Но гол не засчитан");
                    }

                }
                else
                {
                    if (scored == game.Second)
                        game.goalCount[1]++;
                    else
                    {
                        if (scored == game.First && rnd.Next(0, 100) > 50)
                        {
                            game.goalCount[0]++;
                            writer.WriteLine("Но гол засчитан");
                        }
                        else writer.WriteLine("Гол не засчитан");
                    }
                }
            }
        }

        public void NoticeFoul(Team scored) //передаётся команда нарушившая  правила
        {
            writer.WriteLine($"Команда {scored.Name} нарушила правила!");
        }

    }

}
