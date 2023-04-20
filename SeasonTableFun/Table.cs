using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            WriteLineWithPadding("", "Lag", "Kamper", "Vunnet", "Tapt", "Uavgjorte", "Scorede", "Baklengs", "Målforskjell", "Siste fem", "Poeng");


            for (int i = 0; i < _tableLines.Count; i++)
            {
                _tableLines[i].PrintTableLine(i);
            }
        }

        public static void WriteLineWithPadding(params string[] texts)
        {
            for (var index = 0; index < texts.Length; index++)
            {
                var padding = index switch
                {
                    0 => 0,
                    1 => 30,
                    8 => 15,
                    _ => 10
                };
                Console.Write(texts[index].PadRight(padding));
            }
            Console.WriteLine();
        }
    }
}
