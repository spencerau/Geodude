namespace Cpsc370Final;

public class Player
{
    private double money;
    private Dictionary<EChips, int> chips;
    private int chipCount;

    public Player()
    {
        money = 100.00;
        chips = new Dictionary<EChips, int>();
        for (int i = 0; i < 5; i++)
        {
            chips.Add((EChips)i, 0);
        }
        chipCount = CountChips();
    }

    public void ShowStatus()
    {
        Console.WriteLine($"You currently have ${money} to gamble or exchange to chips.");
        Console.WriteLine($"From your chips you have to {chipCount} chips:");
        foreach (KeyValuePair<EChips, int> entry in chips)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }

    public void AddChips(int chip, int multiplier)
    {
    }

    private int CountChips()
    {
        int currCount = 0;
        foreach (KeyValuePair<EChips, int> entry in chips)
        {
            currCount += entry.Value;
        }
        return currCount;
    }
}