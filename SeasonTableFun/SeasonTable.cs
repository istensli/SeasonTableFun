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

        public void Show()
        {       
            var tableLines = new List<TableLine>();
            foreach (var team in _teams) 
            {
                tableLines.Add(new TableLine(team));
            }

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
                    tableLines[indexOfHomeTeam].AddPoints(3);

                else if (indexOfAwayTeam != -1 && match.HomeScore < match.AwayScore)
                    tableLines[indexOfAwayTeam].AddPoints(3);
                else 
                {   //ved uavgjort deles ut ett poeng til hver
                    tableLines[indexOfHomeTeam].AddPoints(1);
                    tableLines[indexOfAwayTeam].AddPoints(1);

                }
            }
            var sortedTableLines = tableLines.OrderByDescending(l => l.Points)
                .ThenByDescending(l => l.GoalDifference)
                .ThenByDescending(l => l.GoalsScored)
                .ThenBy(l => l.Team.Name).ToList();//etterhvert sortere på målforskjell osv

            Console.WriteLine("Lag".PadRight(30) + "Antall kamper".PadRight(20) + "Scorede mål".PadRight(20) + "Baklengsmål".PadRight(20) +
                "Målforskjell".PadRight(20)  + "Poeng".PadRight(20));
            for (int i = 0; i < sortedTableLines.Count; i++) 
            {
                Console.WriteLine($"{i+1}.{sortedTableLines[i].Team.Name.PadRight(30)}" +
                                    $"{Convert.ToString(sortedTableLines[i].NumberOfMatchesPlayed).PadRight(20)}" +
                                    $"{Convert.ToString(sortedTableLines[i].GoalsScored).PadRight(20)}" +
                                    $"{Convert.ToString(sortedTableLines[i].GoalsConceded).PadRight(20)}" +
                                    $"{Convert.ToString(sortedTableLines[i].GoalDifference).PadRight(20)}" +
                                    $"{Convert.ToString(sortedTableLines[i].Points).PadRight(20)}");
            }


        }
    }
}
