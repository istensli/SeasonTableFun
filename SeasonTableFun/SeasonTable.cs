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




        public void Show()
        {
            Table table = new Table(_teams, _matches);
            table.SortTable();
            table.PrintTable();

        }
    }
}
