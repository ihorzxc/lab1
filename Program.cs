
using Lab1OOP;

GameAccount pl1 = new GameAccountWinRewardInARow("pl1");
GameAccount pl2 = new GameAccountLosePunishInARow("pl2");

Games games = new Games();
var game = games.GetGame();

Console.WriteLine($"You play {game.GameType()}");

//game.play(pl1, pl2, -10);// that will cause error
game.play(pl1, pl2, 15);
game.play(pl2, pl1, 10);
game.play(pl1, pl2, 30);
game.play(pl1, pl2, 20);
game.play(pl1, pl2, 1); 
pl1.GetStats();
pl2.GetStats();

Console.WriteLine("Game history");
game.GetStats();
