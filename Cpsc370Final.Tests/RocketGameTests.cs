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
            var game = new RocketGame();
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
    }
}