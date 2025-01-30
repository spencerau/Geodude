namespace Cpsc370Final;

public class Player
{
    public double money { get; private set; }

    public Player(double startingMoney)
    {
        money = startingMoney;
    }

    public void ShowStatus()
    {
        Console.WriteLine($"You currently have ${money} to gamble.");
    }

    public void AddMoney(double moneyBet, int multiplier)
    {
        money += moneyBet * multiplier;
    }

    public double RemoveMoney(double moneyBet)
    {
        money -= moneyBet;
        return moneyBet;
    }

    public bool HasMoney()
    {
        return money > 0.0;
    }
}