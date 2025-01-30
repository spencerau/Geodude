namespace Cpsc370Final.Tests;

public class PlayerTest
{
    [Fact]
    public void TestPlayer()
    {
        Player player = new Player(100.0);
        
        Assert.True(player != null);
    }

    [Fact]
    public void CanShowStatus()
    {
        Player player = new Player(100.00);
        
        player.ShowStatus();
    }

    [Theory]
    [InlineData(3, 2)]
    public void TestAddingMoney(double moneyBet, int times)
    {
        Player player = new Player(100.00);
        player.AddMoney(moneyBet, times);

        Assert.True(player.money == 106.0);
    }

    [Theory]
    [InlineData(10.0)]
    public void TestRemovingMoney(double moneyBet)
    {
        Player player = new Player(100.00);
        player.RemoveMoney(moneyBet);
        Assert.True(player.money == 90.0);
    }
}