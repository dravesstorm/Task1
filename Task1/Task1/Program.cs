using System;
using System.Collections.Generic;
using System.Linq;
using Task1.Services;
using Task1.Models;
using System.IO;


namespace Task1
{
    public class Program
    {
        public static void Main()
        {
            string path = @"../../result.txt";
            IWriter cw = new ConsoleWriter();
            FileWriter filewriter = new FileWriter();
            filewriter.sw = File.CreateText(path);
            IWriter fw = filewriter;

            Trainer tr_bars = new Trainer("Valverde");

            Team bars = new Team("Barselona", tr_bars);
            TeamService barselonaServices = new TeamService(bars, cw);

            //добавление футболистов
            barselonaServices.Add(new Footballer("Tolmachev", 32));
            barselonaServices.Add(new Footballer("Pyatigoret", 21));
            barselonaServices.Add(new Footballer("Silverman", 22));
            barselonaServices.Add(new Footballer("PacitoSouza", 24));
            barselonaServices.Add(new Footballer("Souza", 25));
            barselonaServices.Add(new Footballer("Akinshin", 31));
            barselonaServices.Add(new Footballer("Murphey", 21));
            barselonaServices.Add(new Footballer("Irvin", 19));
            barselonaServices.Add(new Footballer("Good", 26));
            barselonaServices.Add(new Footballer("Rosario ", 28));

            //добавление и удаление футболиста
            Footballer senior = new Footballer("McKinstry ", 33);
            barselonaServices.Add(senior);
            barselonaServices.MyTeam.team.Remove(senior);

            barselonaServices.Add(new Footballer("Emelianenko ", 26));

            barselonaServices.Show();
            cw.WriteLine("\nПопытка добавить 12 игрока");
            barselonaServices.Add(new Footballer("McKinstry ", 32));
            cw.WriteLine("Игроки старше 30 лет:");
            barselonaServices.ShowSenior();
            barselonaServices.ShowTrainer();
            cw.WriteLine("\n\n");


            Trainer tr_real = new Trainer("Zidane");

            Team real = new Team("Real-Madrid", tr_real);


            TeamService realServices = new TeamService(real, cw);


            realServices.Add(new Footballer("Abraham", 32));
            realServices.Add(new Footballer("Main", 21));
            realServices.Add(new Footballer("Deason", 22));
            realServices.Add(new Footballer("Schwenk", 24));
            realServices.Add(new Footballer("Whitlock", 25));
            realServices.Add(new Footballer("Prasad", 31));
            realServices.Add(new Footballer("Villamor", 21));
            realServices.Add(new Footballer("Stromberg ", 19));
            realServices.Add(new Footballer("Johnson", 26));
            realServices.Add(new Footballer("Kendall ", 28));
            realServices.Add(new Footballer("Vanderford ", 32));

            realServices.Show();
            realServices.ShowTrainer();
            cw.WriteLine("\n\n");

            Refery skomina = new Refery("Skomina", Preferences.FirstTeam);

            Game FIFA1 = new Game(barselonaServices.MyTeam, realServices.MyTeam, skomina);
            GameService FIFA1service = new GameService(FIFA1, cw);

            FIFA1service.Start();
            cw.WriteLine();
            FIFA1service.ShowPredictions();
            cw.WriteLine(); 
            FIFA1service.eGoal += FIFA1service.NoticeGoal;
            FIFA1service.Goal(bars);
            FIFA1service.Goal(real);
            FIFA1service.ShowGoalCount();

            //исход матча зависит от удачи тренера уровня навыка футболистов
            FIFA1service.ShowResult();
            filewriter.sw.Close();
            Console.ReadKey();
        }
    }
}