namespace Lab1OOP;

public class GameAccount
{
    public string UserName = "None";
    public int CurrentRating;
    private int GamesCount = 0;
    private List<GameDTO> opponenthistory = new List<GameDTO>();

    public GameAccount(string UserName)
    {
        this.UserName = UserName;
        CurrentRating = 100;
    }
    
    public GameAccount()
    {
        CurrentRating = 100;
        
    }

    public void WinGame(GameAccount opponent, int Rating, int index)
    {
        CurrentRating += Rating;
        GameDTO game = new GameDTO(opponent, this, Rating, index);
        opponenthistory.Add(game);
    }
    
    public void LoseGame(GameAccount opponent, int Rating, int index)
    {
        CurrentRating -= Rating;
        GameDTO game = new GameDTO(this, opponent, Rating, index);
        opponenthistory.Add(game);
    }

    public void GetStats()
    {
        Console.WriteLine($"History of {UserName}");
        for (int i = 0; i < opponenthistory.Count; i++)
        {
            Console.WriteLine($"Game {opponenthistory[i].index}");
            if (opponenthistory[i].winner == this)
            {
                Console.WriteLine($"\twon against {opponenthistory[i].loser.UserName}");
            }
            else
            {
                Console.WriteLine($"\tlose against {opponenthistory[i].winner.UserName}");
            }
            
            
            Console.WriteLine($"\tRate {opponenthistory[i].Rate}");
        }
        Console.WriteLine($"Now {UserName} has {CurrentRating} points\n");
    }
}