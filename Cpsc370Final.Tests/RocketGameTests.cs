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

        // below is a more comprehensive test to show a real game flow

        [Fact]
        public void SimulateFullGameFlow_ScenarioExample()
        {
            // arrange
            var game = new RocketGame();
            // player starts with a temporary balance of 1000.0 by default.

            // round #1: player wants to bet 100, picks "go", outcome forced to success
            game.PlaceBet(100);
            Assert.Equal(900, game.TemporaryBalance, 5);  // 1000 - 100
            game.InputGuesses("go");

            game.GenerateOutcome();
            game.Outcome = true; // Force a successful rocket

            // act
            double round1Winnings = game.DisplayResult();

            // assert
            Assert.True(game.CheckWin());
            Assert.Equal(110, round1Winnings, 5);         // 1.1x the bet
            Assert.Equal(1010, game.TemporaryBalance, 5); // 900 + 110

            // player decides to restart and play again
            game.RestartGame();
            Assert.Equal(0, game.BetAmount, 5);
            Assert.Null(game.PlayerGuess);

            // round #2: player wants to bet 200, picks "go", outcome forced to fail
            game.PlaceBet(200);
            Assert.Equal(810, game.TemporaryBalance, 5);  // 1010 - 200
            game.InputGuesses("go");

            game.GenerateOutcome();
            game.Outcome = false; // force rocket fail

            double round2Winnings = game.DisplayResult();

            // assert
            Assert.False(game.CheckWin());
            Assert.Equal(0, round2Winnings, 5);
            Assert.Equal(810, game.TemporaryBalance, 5); // no change since lost
        }



        [Theory]
        [InlineData(@"100, go
0
")]         // Bet 100, guess "go", then bet 0 => exit
        [InlineData(@"abc
")]         // Invalid bet => test flow
        [InlineData(@"100

0
")]         // Valid bet => missing guess => invalid guess => next => 0 => exit
        public void TestPlayRocketGame(string fakeInput)
        {
            // Arrange
            var game = new RocketGame();

            // Setup fake console input
            using var input = new StringReader(fakeInput);
            Console.SetIn(input);

            // Capture console output in a StringWriter
            using var output = new StringWriter();
            var originalOutput = Console.Out;
            Console.SetOut(output);

            // Act
            game.PlayRocketGame();

            // Restore original console output
            Console.SetOut(originalOutput);

            // Grab everything that was printed
            string consoleOutput = output.ToString();

            // Assert something about the final state or console text
            // For example, maybe ensure we never go below zero balance:
            Assert.True(game.TemporaryBalance >= 0);

            // Or ensure the text includes "Thanks for playing"
            Assert.Contains("Thanks for playing", consoleOutput);
        }
    }
}