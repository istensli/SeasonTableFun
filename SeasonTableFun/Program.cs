using SeasonTableFun;




var theBigSix = new[] { "Boca Juniors", "River Plate", "Racing Club" , "Independiente", "San Lorenzo", "Huracán"};

var seasonTable = new SeasonTable(theBigSix);

seasonTable.AddMatch(0, 1, 1, 4);
seasonTable.AddMatch(2, 3, 2, 1);
seasonTable.AddMatch(4, 5, 0, 2);

seasonTable.AddMatch(1, 0, 2, 2);
seasonTable.AddMatch(3, 2, 1, 1);
seasonTable.AddMatch(5, 4, 3, 2);

seasonTable.AddMatch(0, 2, 2, 2);
seasonTable.AddMatch(3, 5, 1, 1);
seasonTable.AddMatch(1, 4, 3, 2);

seasonTable.AddMatch(2, 4, 2, 2);
seasonTable.AddMatch(0, 3, 1, 1);
seasonTable.AddMatch(1, 5, 3, 2);

seasonTable.AddMatch(4, 2, 2, 2);
seasonTable.AddMatch(3, 0, 1, 1);
seasonTable.AddMatch(5, 1, 3, 2);

seasonTable.Show();

seasonTable.PrintLastFiveMatches();



//var team1 = new Team("San Lorenzo");
//var team2 = new Team("Rosario Central");

//var seasonTable = new SeasonTable(new[] {teamA, teamB,});

//seasonTable.AddMatch(new Match(teamA, teamB, 3, 2));
//seasonTable.AddMatch(new Match(teamB, teamA, 0, 0));
