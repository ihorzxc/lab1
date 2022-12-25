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

public abstract class BaseGame
{
    public abstract string GameType();
    
    public List<GameDTO> gamehistory = new List<GameDTO>();
    protected int index = 0;
    public abstract void play(GameAccount winner, GameAccount loser, int Rate);
    
    public void GetStats()
    {
        for (int i = 0; i < gamehistory.Count; i++)
        {
            Console.WriteLine($"Game {i}\n{gamehistory[i].winner.UserName} (+{gamehistory[i].Rate} points) won\n{gamehistory[i].loser.UserName} (-{gamehistory[i].Rate} points) lose");
        }
    }
}

public class Game : BaseGame
{
    public override void play(GameAccount winner, GameAccount loser, int Rate)
    {
        if (Rate < 0)
        {
            throw new Exception("Rating can not be negative number");
        }
        if (Rate + 1 <= loser.CurrentRating)
        {
            GameDTO thisgame = new GameDTO(loser, winner, Rate, index);
            gamehistory.Add(thisgame);
            winner.WinGame(this);
            loser.LoseGame(this);
            
            index += 1;
        }
    }

    public override string GameType()
    {
        return "Game";
    }
}

public class TrainGame : BaseGame
{
    public override void play(GameAccount winner, GameAccount loser, int Rate)
    {
        if (Rate < 0)
        {
            throw new Exception("Rating can not be negative number");
        }
        if (Rate + 1 <= loser.CurrentRating)
        {
            GameDTO thisgame = new GameDTO(loser, winner, 0, index);
            gamehistory.Add(thisgame);
            winner.WinGame(this);
            loser.LoseGame(this);
            
            index += 1;
        }
    }

    public override string GameType()
    {
        return "TrainGame";
    }
}

public class DoubleRatingGame : BaseGame
{
    public override void play(GameAccount winner, GameAccount loser, int Rate)
    {
        if (Rate < 0)
        {
            throw new Exception("Rating can not be negative number");
        }
        if (2 * Rate + 1 <= loser.CurrentRating)
        {
            GameDTO thisgame = new GameDTO(loser, winner, 2 * Rate, index);
            gamehistory.Add(thisgame);
            winner.WinGame(this);
            loser.LoseGame(this);

            index += 1;
        }
    }

    public override string GameType()
    {
        return "DoubleRatingGame";
    }
}