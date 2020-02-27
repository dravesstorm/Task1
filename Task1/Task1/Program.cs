using System;
using System.Collections.Generic;
using System.Linq;
using Task1.Services;
using Task1.Models;

namespace Task1
{
    public class Program
    {
        public static void Main()
        {
            Trainer tr_bars = new Trainer("Valverde");

            Team bars = new Team("Barselona", tr_bars);
            TeamService BarselonaServices = new TeamService(bars);

            BarselonaServices.Add(new Footballer("Tolmachev", 32));
            BarselonaServices.Add(new Footballer("Pyatigoret", 21));
            BarselonaServices.Add(new Footballer("Silverman", 22));
            BarselonaServices.Add(new Footballer("PacitoSouza", 24));
            BarselonaServices.Add(new Footballer("Souza", 25));
            BarselonaServices.Add(new Footballer("Akinshin", 31));
            BarselonaServices.Add(new Footballer("Murphey", 21));
            BarselonaServices.Add(new Footballer("Irvin", 19));
            BarselonaServices.Add(new Footballer("Good", 26));
            BarselonaServices.Add(new Footballer("Rosario ", 28));
            BarselonaServices.Add(new Footballer("McKinstry ", 32));

            BarselonaServices.Show();
            BarselonaServices.ShowTrainer();
            Console.WriteLine("\n\n");


            Trainer tr_real = new Trainer("Zidane");

            Team real = new Team("Real-Madrid", tr_real);
            TeamService RealServices = new TeamService(real);

            RealServices.Add(new Footballer("Abraham", 32));
            RealServices.Add(new Footballer("Main", 21));
            RealServices.Add(new Footballer("Deason", 22));
            RealServices.Add(new Footballer("Schwenk", 24));
            RealServices.Add(new Footballer("Whitlock", 25));
            RealServices.Add(new Footballer("Prasad", 31));
            RealServices.Add(new Footballer("Villamor", 21));
            RealServices.Add(new Footballer("Stromberg ", 19));
            RealServices.Add(new Footballer("Johnson", 26));
            RealServices.Add(new Footballer("Kendall ", 28));
            RealServices.Add(new Footballer("Vanderford ", 32));

            RealServices.Show();
            RealServices.ShowTrainer();
            Console.WriteLine("\n\n");

            Refery skomina = new Refery("Skomina", Preferences.firstTeam);

            Game FIFA1 = new Game(BarselonaServices.MyTeam, RealServices.MyTeam, skomina);
            //Game FIFA1 = new Game(bars, real, skomina);
            GameService FIFA1service = new GameService(FIFA1);

            FIFA1service.Start();
            FIFA1service.eGoal += FIFA1service.NoticeGoal;
            FIFA1service.Goal(bars);
            FIFA1service.Goal(real);
            FIFA1service.ShowGoalCount();
            Console.ReadKey();
        }
    }
}