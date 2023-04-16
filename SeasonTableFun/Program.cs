using SeasonTableFun;

var superligaArg = new Team[] {new Team("Boca Juniors"),
                            new Team("River Plate"),
                            new Team("Racing Club"),
                            new Team("Independiente"),
                            new Team("San Lorenzo"),
                            new Team("Newell's Old Boys"),
                            new Team("Rosario Central"),
                            new Team("Vélez Sársfield"),
                            new Team("Huracan"),
                            new Team("Estudiantes"),
                            new Team("Talleres"),
                            new Team("Lanús"),
                            new Team("Banfield"),
                            new Team("Argentinos Juniors"),
                            new Team("Gimnasia"),
                            new Team("Colón"),
                            new Team("Belgrano"),
                            new Team("Instituto"),
                            new Team("Godoy Cruz"),
                            new Team("Tigre"),
                            new Team("Sarmiento"),
                            new Team("Unión de Santa Fe"),
                            new Team("Barracas Central"),
                            new Team("Atletico Tucuman"),
                            new Team("Platense"),
                            new Team("Defensa y Justicia"),
                            new Team("Arsenal de Sarandí"),
                            new Team("Central Cordoba")
                            };

var seasonTable = new SeasonTable(superligaArg);

seasonTable.AddMatch(new Match(superligaArg[0], superligaArg[1], 1, 4));
seasonTable.AddMatch(new Match(superligaArg[2], superligaArg[3], 2, 1));
seasonTable.AddMatch(new Match(superligaArg[4], superligaArg[5], 0, 2));
seasonTable.AddMatch(new Match(superligaArg[6], superligaArg[7], 1, 1));
seasonTable.AddMatch(new Match(superligaArg[8], superligaArg[9], 0, 0));
seasonTable.AddMatch(new Match(superligaArg[10], superligaArg[11], 1, 2));

seasonTable.AddMatch(new Match(superligaArg[1], superligaArg[13], 2, 1));


seasonTable.Show();

seasonTable.PrintLastFiveMatches();






//var team1 = new Team("San Lorenzo");
//var team2 = new Team("Rosario Central");

//var seasonTable = new SeasonTable(new[] {teamA, teamB,});

//seasonTable.AddMatch(new Match(teamA, teamB, 3, 2));
//seasonTable.AddMatch(new Match(teamB, teamA, 0, 0));
