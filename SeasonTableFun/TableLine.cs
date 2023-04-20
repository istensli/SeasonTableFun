using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonTableFun
{
    internal class TableLine
    {
        public Team Team { get; }

        public List<char> _lastFive = new List<char>();
        
        public int Points { get; set; }
        public int NumberOfMatchesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }

        public int GoalDifference => GoalsScored - GoalsConceded;

        public int Won { get; set; }
        public int Draws { get; set; }
        public int Lost { get; set; }



        public TableLine(Team team) 
        {
            Team = team;
        }
        public void AddPoints(int points)
        {
            Points += points;
        }

        
        public void AddWin(int goalsScored, int goalsConceded)
        {
            Won++;
            AddPoints(3);
            NumberOfMatchesPlayed++;
            GoalsScored += goalsScored;
            GoalsConceded += goalsConceded;
            _lastFive.Add('W');
            if(_lastFive.Count > 5) _lastFive.RemoveAt(0);


        }

        public void AddDefeat(int goalsScored, int goalsConceded)
        {
            Lost++;
            NumberOfMatchesPlayed++;
            GoalsScored += goalsScored;
            GoalsConceded += goalsConceded;
            _lastFive.Add('L');
            if (_lastFive.Count > 5) _lastFive.RemoveAt(0);


        }
        public void AddDraw(int goalsScored, int goalsConceded)
        {
            Draws++;
            AddPoints(1);
            NumberOfMatchesPlayed++;
            GoalsScored += goalsScored;
            GoalsConceded += goalsConceded;
            _lastFive.Add('D');
            if (_lastFive.Count > 5) _lastFive.RemoveAt(0); //hmm...burde kanskje fjerne alle eldre enn siste 5, ikke bare den siste(hvis det har blitt noe feil..)?


        }
        public string GetLastFive() 
        {
            string lastFive = "";
            foreach(var match in _lastFive) 
            {
                lastFive += match;
            }
            return lastFive;
        }




        public void PrintTableLine(int index) 
        {
            Table.WriteLineWithPadding($"{index + 1}.",
                                    $"{Team.Name}",
                                    $"{NumberOfMatchesPlayed}",
                                    $"{Won}",
                                    $"{Lost}",
                                    $"{Draws}",
                                    $"{GoalsScored}",
                                    $"{GoalsConceded}",
                                    $"{GoalDifference}",
                                    $"{GetLastFive()}",
                                    $"{Points}");
            
        }
    }
}
