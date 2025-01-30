using System;
using System.IO;
using Xunit;

namespace Cpsc370Final.Tests
{
    public class RocketGameTests
    {
        [Fact]
        public void CheckWin_WhenRocketSafeAndGuessGo_ReturnsTrue()
        {
            // arrange
            var game = new RocketGame();
            game.PlaceBet(100);
            game.InputGuesses("go");

            // force outcome to be safe 
            game.GenerateOutcome();
            game.Outcome = true;

            // act
            bool result = game.CheckWin();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void CheckWin_WhenRocketFailsAndGuessNotGo_ReturnsTrue()
        {
            // arrange
            var random = new Random(0);
            var game = new RocketGame(random);
            game.PlaceBet(50);
            game.InputGuesses("not go");

            // force outcome to be fail
            game.GenerateOutcome();
            game.Outcome = false;

            // act
            bool result = game.CheckWin();

            // assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(100, "go", true, 50, "not go", false, "n")]
        public void SimulateRocketGame(
            double firstBet, string firstGuess, bool firstOutcome,
            double secondBet, string secondGuess, bool secondOutcome,
            string exitChoice)
        {
            // arrange
            var random = new Random(0); // seeded random
            var game = new RocketGame(random);

            // first round
            game.PlaceBet(firstBet);
            game.InputGuesses(firstGuess);
            game.Outcome = firstOutcome; // force outcome
            double firstWinnings = game.DisplayResult();

            // assert first round
            Assert.Equal(firstOutcome ? firstBet * 1.1 : 0, firstWinnings);

            // second round
            game.PlaceBet(secondBet);
            game.InputGuesses(secondGuess);
            game.Outcome = secondOutcome; // Force outcome
            double secondWinnings = game.DisplayResult();

            // assert second round
            Assert.Equal(secondOutcome ? secondBet * 1.1 : 0, secondWinnings);

            // simulate player choosing to leave
            Assert.Equal("n", exitChoice.ToLower());
        }
    }
}