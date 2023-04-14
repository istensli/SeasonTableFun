using System.Collections.Generic;

namespace SeasonTableFun
{
    internal class SeasonTable
    {
        private readonly List<Match> _matches;
        private readonly Team[] _teams;

        public SeasonTable(Team[] teams)
        {
            _matches = new List<Match>();
            _teams = teams;
        }

        public void AddMatch(Match match)
        {
            _matches.Add(match);

        }

        public void PrintLastFiveMatches() 
        {
            int matchesIndexToStart = _matches.Count - 5;
            if (_matches.Count - 5 < 0) matchesIndexToStart = 0;

            Console.Write("\n\n");
            for (int i = (matchesIndexToStart); i < _matches.Count; i++)
            {
                Console.WriteLine($"{_matches[i].HomeTeam.Name}".PadRight(30) + "\t - \t" +
                    $"{_matches[i].AwayTeam.Name}".PadRight(30) +
                    $"{_matches[i].HomeScore} - {_matches[i].AwayScore}".PadRight(30));
            }
        }


        //denner metode er for stor. foreslår å dele opp i: -private List<TableLine> CreateTableLines(), eller??
        //                                                 - private List<TableLine> AddMatchesToTableLines(List<TableLine> tableLines)
        //                                                  -private List<TableLine> GetSortedTableLines(List<TableLine> tableLines)
        //-Show kan kjøre de tre over, så kjøre Console.Writeline...

        private List<TableLine> CreateTableLines() 
        {
            var tableLines = new List<TableLine>();
            foreach (var team in _teams)
            {
                tableLines.Add(new TableLine(team));
            }
            return tableLines;

        }

        //kunne hatt annet navn i og med at den returnerer en liste
        private List<TableLine> AddMatchesToTableLines(List<TableLine> tableLines) 
        {
            foreach (Match match in _matches)
            {
                int indexOfHomeTeam = tableLines.FindIndex(l => l.Team == match.HomeTeam);
                int indexOfAwayTeam = tableLines.FindIndex(l => l.Team == match.AwayTeam);
                tableLines[indexOfHomeTeam].GoalsScored += match.HomeScore;
                tableLines[indexOfHomeTeam].GoalsConceded += match.AwayScore;
                tableLines[indexOfHomeTeam].NumberOfMatchesPlayed++;
                tableLines[indexOfAwayTeam].NumberOfMatchesPlayed++;

                tableLines[indexOfAwayTeam].GoalsScored += match.AwayScore;
                tableLines[indexOfAwayTeam].GoalsConceded += match.HomeScore;

                if (indexOfHomeTeam != -1 && match.HomeScore > match.AwayScore)
                {
                    tableLines[indexOfHomeTeam].Won++;
                    tableLines[indexOfAwayTeam].Lost++;
                    tableLines[indexOfHomeTeam].AddPoints(3);
                }

                else if (indexOfAwayTeam != -1 && match.HomeScore < match.AwayScore)
                {
                    tableLines[indexOfAwayTeam].Won++;
                    tableLines[indexOfHomeTeam].Lost++;
                    tableLines[indexOfAwayTeam].AddPoints(3);
                }
                else
                {   //ved uavgjort deles ut ett poeng til hver
                    tableLines[indexOfHomeTeam].Draws++;
                    tableLines[indexOfAwayTeam].Draws++;
                    tableLines[indexOfHomeTeam].AddPoints(1);
                    tableLines[indexOfAwayTeam].AddPoints(1);

                }
            }
            return tableLines;

        }

        private List<TableLine> GetSortedTableLines(List<TableLine> tableLines)
        {
            var sortedTableLines = tableLines.OrderByDescending(l => l.Points)
               .ThenByDescending(l => l.GoalDifference)
               .ThenByDescending(l => l.GoalsScored)
               .ThenBy(l => l.Team.Name).ToList();
            return sortedTableLines;

        }




        public void Show()
        {
            

            var sortedTableLines = GetSortedTableLines(AddMatchesToTableLines(CreateTableLines()));
            



            Console.WriteLine("Lag".PadRight(30) + "Kamper".PadRight(10) +
                "Vunnet".PadRight(10) +
                "Tapt".PadRight(10) +
                "Uavgjorte".PadRight(10) +
                "Scorede".PadRight(10) +
                "Baklengs".PadRight(10) +
                "Målforskjell".PadRight(15) +
                "Poeng".PadRight(10));

            for (int i = 0; i < sortedTableLines.Count; i++) 
            {
                Console.WriteLine($"{i+1}.{sortedTableLines[i].Team.Name.PadRight(30)}" +
                                    $"{Convert.ToString(sortedTableLines[i].NumberOfMatchesPlayed).PadRight(10)}" +
                                    $"{Convert.ToString(sortedTableLines[i].Won).PadRight(10)}" +
                                    $"{Convert.ToString(sortedTableLines[i].Lost).PadRight(10)}" +
                                    $"{Convert.ToString(sortedTableLines[i].Draws).PadRight(10)}" +
                                    $"{Convert.ToString(sortedTableLines[i].GoalsScored).PadRight(10)}" +
                                    $"{Convert.ToString(sortedTableLines[i].GoalsConceded).PadRight(10)}" +
                                    $"{Convert.ToString(sortedTableLines[i].GoalDifference).PadRight(15)}" +
                                    $"{Convert.ToString(sortedTableLines[i].Points).PadRight(10)}");
            }


        }
    }
}
