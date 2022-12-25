namespace Lab1OOP;

public class Games
{
    public BaseGame GetGame()
    {
        return new Game();
    }
    public BaseGame GetTrain()
    {
        return new TrainGame();
    }
    public BaseGame GetDoubleRatingGame()
    {
        return new DoubleRatingGame();
    }
}