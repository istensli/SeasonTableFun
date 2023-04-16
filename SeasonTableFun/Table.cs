using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeasonTableFun
{
    internal class Table
    {
        private List<TableLine> _tableLines = new List<TableLine>();

        public Table(Team[] teams, List<Match> matches)
        {
            AddTeamsToTable(teams);
            AddMatchesToTable(matches);

        }

        private void AddTeamsToTable(Team[] teams)
        {

            foreach (var team in teams)
            {
                _tableLines.Add(new TableLine(team));
            }

        }
        private int AddMatchesToTable(List<Match> matches)
        {
            foreach (Match match in matches)
            {
                int indexOfHomeTeam = _tableLines.FindIndex(l => l.Team == match.HomeTeam);
                int indexOfAwayTeam = _tableLines.FindIndex(l => l.Team == match.AwayTeam);

                if (indexOfHomeTeam == -1 || indexOfAwayTeam == -1) return 1;

                _tableLines[indexOfHomeTeam].GoalsScored += match.HomeScore;
                _tableLines[indexOfHomeTeam].GoalsConceded += match.AwayScore;
                _tableLines[indexOfHomeTeam].NumberOfMatchesPlayed++;
                _tableLines[indexOfAwayTeam].NumberOfMatchesPlayed++;

                _tableLines[indexOfAwayTeam].GoalsScored += match.AwayScore;
                _tableLines[indexOfAwayTeam].GoalsConceded += match.HomeScore;

                if (match.HomeScore > match.AwayScore)
                {
                    _tableLines[indexOfHomeTeam].Won++;
                    _tableLines[indexOfAwayTeam].Lost++;
                    _tableLines[indexOfHomeTeam].AddPoints(3);
                }

                else if (match.HomeScore < match.AwayScore)
                {
                    _tableLines[indexOfAwayTeam].Won++;
                    _tableLines[indexOfHomeTeam].Lost++;
                    _tableLines[indexOfAwayTeam].AddPoints(3);
                }
                else
                {   //ved uavgjort deles ut ett poeng til hver
                    _tableLines[indexOfHomeTeam].Draws++;
                    _tableLines[indexOfAwayTeam].Draws++;
                    _tableLines[indexOfHomeTeam].AddPoints(1);
                    _tableLines[indexOfAwayTeam].AddPoints(1);

                }

            }
            return 0;
        }
        //egentlig kunne PrintTable kjørt SortTable()
        public void SortTable()
        {
            _tableLines = _tableLines.OrderByDescending(l => l.Points)
               .ThenByDescending(l => l.GoalDifference)
               .ThenByDescending(l => l.GoalsScored)
               .ThenBy(l => l.Team.Name).ToList();

        }
        public void PrintTable()
        {
            Console.WriteLine("Lag".PadRight(30) + "Kamper".PadRight(10) +
                "Vunnet".PadRight(10) +
                "Tapt".PadRight(10) +
                "Uavgjorte".PadRight(10) +
                "Scorede".PadRight(10) +
                "Baklengs".PadRight(10) +
                "Målforskjell".PadRight(15) +
                "Poeng".PadRight(10));

            for (int i = 0; i < _tableLines.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{_tableLines[i].Team.Name}".PadRight(30) +
                                    $"{_tableLines[i].NumberOfMatchesPlayed}".PadRight(10) +
                                    $"{_tableLines[i].Won}".PadRight(10) +
                                    $"{_tableLines[i].Lost}".PadRight(10) +
                                    $"{_tableLines[i].Draws}".PadRight(10) +
                                    $"{_tableLines[i].GoalsScored}".PadRight(10) +
                                    $"{_tableLines[i].GoalsConceded}".PadRight(10) +
                                    $"{_tableLines[i].GoalDifference}".PadRight(15) +
                                    $"{_tableLines[i].Points}".PadRight(10));
            }
        }
    }
}
