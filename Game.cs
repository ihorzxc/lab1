namespace Lab1OOP;

public class GameDTO
{
    public int index;
    public GameAccount loser;
    public GameAccount winner;
    public int Rate;
    public GameDTO(GameAccount loser, GameAccount winner, int rate, int index)
    {
        this.loser = loser;
        this.winner = winner;
        Rate = rate;
        this.index = index;
    }
}

public class Game
{
    private List<GameDTO> gamehistory = new List<GameDTO>();
    private int index = 0;
    public void play(GameAccount winner, GameAccount loser, int Rate)
    {
        if (Rate < 0)
        {
            throw new Exception("Rating can not be negative number");
        }
        else if (Rate + 1 <= loser.CurrentRating)
        {
            winner.WinGame(loser, Rate, index);
            loser.LoseGame(winner, Rate, index);
            GameDTO thisgame = new GameDTO(loser, winner, Rate, index);
            gamehistory.Add(thisgame);
            index += 1;
        }
    }

    public void GetStats()
    {
        for (int i = 0; i < gamehistory.Count; i++)
        {
            Console.WriteLine($"Game {i}\n{gamehistory[i].winner.UserName} (+{gamehistory[i].Rate} points) won\n{gamehistory[i].loser.UserName} (-{gamehistory[i].Rate} points) lose");
        }
    }
}