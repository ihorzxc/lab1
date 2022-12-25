
using Lab1OOP;

GameAccount pl1 = new GameAccount("pl1");
GameAccount pl2 = new GameAccount("pl2");

Game game = new Game();

//game.play(pl1, pl2, -10);// that will cause error
game.play(pl1, pl2, 15);
game.play(pl2, pl1, 10);
game.play(pl1, pl2, 50);
game.play(pl1, pl2, 50);// this game will not be played because account can not have rating less than 1
game.play(pl1, pl2, 1); 
pl1.GetStats();
pl2.GetStats();

Console.WriteLine("Game history");
game.GetStats();
