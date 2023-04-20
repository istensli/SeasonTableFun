using System.Dynamic;

namespace SeasonTableFun
{
    internal class Match
    {
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public int HomeScore { get; }
        public int AwayScore { get; }

        public Match(Team homeTeam, Team awayTeam, int homeScore, int awayScore)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = homeScore;
            AwayScore = awayScore;
        }

        public string GetMatchAsText()
        {
            return $"{HomeTeam.Name}".PadRight(30) + "\t - \t" +
                    $"{AwayTeam.Name}".PadRight(30) +
                    $"{HomeScore} - {AwayScore}".PadRight(30);

        }
    }
}
