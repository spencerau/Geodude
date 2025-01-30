using System;
using Xunit;

public class RouletteTests
{
    [Fact]
    public void GetColor_WhenUserChoosesRed_ShouldReturn0()
    {
        var roulette = new Roulette(() => "red");
        int result = roulette.GetColor();
        Assert.Equal(0, result); // Should return 0 for "red"
    }

    [Fact]
    public void GetColor_WhenUserChoosesBlack_ShouldReturn1()
    {
        var roulette = new Roulette(() => "black");
        int result = roulette.GetColor();
        Assert.Equal(1, result); // Should return 1 for "black"
    }

    [Fact]
    public void PlaceOutsideBet_WhenUserGuessesCorrectColor_ShouldPrintCorrectMessage()
    {
        var roulette = new Roulette(() => "red", random: new RandomStub(0)); // Simulating red (0)
        using (var sw = new System.IO.StringWriter())
        {
            Console.SetOut(sw);
            roulette.PlaceOutsideBet();
            Assert.Contains("You guessed correctly!", sw.ToString());
        }
    }

    [Fact]
    public void PlaceInsideBet_WhenUserBetsCorrectNumber_ShouldPrintWinningMessage()
    {
        var roulette = new Roulette(() => "5", random: new RandomStub(5));
        using (var sw = new System.IO.StringWriter())
        {
            Console.SetOut(sw);
            roulette.PlaceInsideBet();
            Assert.Contains("You win!", sw.ToString());
        }
    }
}

public class RandomStub : Random
{
    private readonly int _fixedValue;

    public RandomStub(int fixedValue)
    {
        _fixedValue = fixedValue;
    }

    public override int Next(int minValue, int maxValue)
    {
        return _fixedValue;
    }
}
