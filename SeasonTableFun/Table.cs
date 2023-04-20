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

        private void AddMatchToTable(TableLine homeTeam, TableLine awayTeam, Match match) 
        {
            if (match.HomeScore > match.AwayScore)
            {
                homeTeam.AddWin(match.HomeScore, match.AwayScore);
                awayTeam.AddDefeat(match.AwayScore, match.HomeScore);

            }
            else if (match.HomeScore < match.AwayScore)
            {
                awayTeam.AddWin(match.AwayScore, match.HomeScore);
                homeTeam.AddDefeat(match.HomeScore, match.AwayScore);

            }
            else
            {
                homeTeam.AddDraw(match.HomeScore, match.AwayScore);
                awayTeam.AddDraw(match.AwayScore, match.HomeScore);

            }

        }

        private void AddMatchesToTable(List<Match> matches)
        {
            
            foreach (Match match in matches)
            {
                
                //homeTeam og awayTeam er objekter av typen TableLine
                var homeTeam = _tableLines.Find(l => l.Team == match.HomeTeam);
                var awayTeam = _tableLines.Find(l => l.Team == match.AwayTeam);
                //logikk for å håndtere at den ikke finner laget...??

                AddMatchToTable(homeTeam, awayTeam, match);

            }
            //return 0;
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
                "Siste fem".PadRight(10) +
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
                                    $"{_tableLines[i].GetLastFive()}".PadRight(10) +
                                    $"{_tableLines[i].Points}".PadRight(10));
            }
        }
    }
}
