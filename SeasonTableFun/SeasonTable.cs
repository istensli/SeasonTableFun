using System.Collections.Generic;

namespace SeasonTableFun
{
    internal class SeasonTable
    {
        private readonly List<Match> _matches;
        private readonly Team[] _teams;

        public SeasonTable(params string[] teamNames)  //(Team[] teams)
        {
            _matches = new List<Match>();
            _teams = teamNames.Select(n => new Team(n)).ToArray();
        }

        public void AddMatch(Match match)
        {
            _matches.Add(match);

        }

        public void AddMatch(int homeTeamIndex, int awayTeamIndex, int homeGoals, int awayGoals)
        {
            var match = new Match(_teams[homeTeamIndex], _teams[awayTeamIndex],homeGoals, awayGoals);
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
