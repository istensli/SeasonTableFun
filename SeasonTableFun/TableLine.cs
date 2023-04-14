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
        public string GetTableLine() //ikke i bruk
        {
            return $"{Team.Name} \t {Points}";
        }
    }
}
