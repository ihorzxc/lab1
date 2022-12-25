namespace Lab1OOP;

public class GameAccount
{
    public string UserName = "None";
    public int CurrentRating;
    private int GamesCount = 0;
    protected List<GameDTO> opponenthistory = new List<GameDTO>();

    public GameAccount(string UserName)
    {
        this.UserName = UserName;
        CurrentRating = 100;
    }
    
    public GameAccount()
    {
        CurrentRating = 100;
        
    }

    public virtual void WinGame(BaseGame game)
    {
        CurrentRating += game.gamehistory[game.gamehistory.Count-1].Rate;
        GameDTO gamehistory = new GameDTO(game.gamehistory[game.gamehistory.Count-1].loser, this, game.gamehistory[game.gamehistory.Count-1].Rate, game.gamehistory[game.gamehistory.Count-1].index);
        opponenthistory.Add(gamehistory);
    }
    public virtual void LoseGame(BaseGame game)
    {
        CurrentRating -= game.gamehistory[game.gamehistory.Count-1].Rate;
        GameDTO gamehistory = new GameDTO(this, game.gamehistory[game.gamehistory.Count-1].winner, game.gamehistory[game.gamehistory.Count-1].Rate, game.gamehistory[game.gamehistory.Count-1].index);
        opponenthistory.Add(gamehistory);
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

public class GameAccountWinRewardInARow : GameAccount
{
    public GameAccountWinRewardInARow(string UserName) : base(UserName)
    {
        this.UserName = UserName;
        CurrentRating = 100;
    }
    
    public GameAccountWinRewardInARow()
    {
        CurrentRating = 100;
        
    }

    public override void WinGame(BaseGame game)
    {
        int bonus = 10;
        CurrentRating += game.gamehistory[game.gamehistory.Count-1].Rate;
        GameDTO gamehistory = new GameDTO(game.gamehistory[game.gamehistory.Count-1].loser, this, game.gamehistory[game.gamehistory.Count-1].Rate, game.gamehistory[game.gamehistory.Count-1].index);
        if (opponenthistory.Count == 0)
        {
            
        }
        else if (opponenthistory[opponenthistory.Count - 1].winner == this)
        {
            CurrentRating += bonus;
        }
        opponenthistory.Add(gamehistory);
    }
    public override void LoseGame(BaseGame game)
    {
        CurrentRating -= game.gamehistory[game.gamehistory.Count-1].Rate;
        GameDTO gamehistory = new GameDTO(this, game.gamehistory[game.gamehistory.Count-1].winner, game.gamehistory[game.gamehistory.Count-1].Rate, game.gamehistory[game.gamehistory.Count-1].index);
        opponenthistory.Add(gamehistory);
    }
}

public class GameAccountLosePunishInARow : GameAccount
{
    public GameAccountLosePunishInARow(string UserName) : base(UserName)
    {
        this.UserName = UserName;
        CurrentRating = 100;
    }
    
    public GameAccountLosePunishInARow()
    {
        CurrentRating = 100;
        
    }

    public override void WinGame(BaseGame game)
    {
        
        CurrentRating += game.gamehistory[game.gamehistory.Count-1].Rate;
        GameDTO gamehistory = new GameDTO(game.gamehistory[game.gamehistory.Count-1].loser, this, game.gamehistory[game.gamehistory.Count-1].Rate, game.gamehistory[game.gamehistory.Count-1].index);
        
        opponenthistory.Add(gamehistory);
    }
    public override void LoseGame(BaseGame game)
    {
        int punish = 10;
        CurrentRating -= game.gamehistory[game.gamehistory.Count-1].Rate;
        GameDTO gamehistory = new GameDTO(this, game.gamehistory[game.gamehistory.Count-1].winner, game.gamehistory[game.gamehistory.Count-1].Rate, game.gamehistory[game.gamehistory.Count-1].index);
        if (opponenthistory.Count == 0)
        {
            
        }
        else if (opponenthistory[opponenthistory.Count - 1].loser == this)
        {
            CurrentRating -= punish;
        }
        opponenthistory.Add(gamehistory);
    }
}

public class GameAccountTrain : GameAccount
{
    public GameAccountTrain(string UserName) : base(UserName)
    {
        this.UserName = UserName;
        CurrentRating = 100;
    }
    
    public GameAccountTrain()
    {
        CurrentRating = 100;
        
    }

    public override void WinGame(BaseGame game)
    {
        GameDTO gamehistory = new GameDTO(game.gamehistory[game.gamehistory.Count-1].loser, this, 0, game.gamehistory[game.gamehistory.Count-1].index);
        opponenthistory.Add(gamehistory);
    }
    public override void LoseGame(BaseGame game)
    {
        GameDTO gamehistory = new GameDTO(this, game.gamehistory[game.gamehistory.Count-1].winner, 0, game.gamehistory[game.gamehistory.Count-1].index);
        opponenthistory.Add(gamehistory);
    }
}