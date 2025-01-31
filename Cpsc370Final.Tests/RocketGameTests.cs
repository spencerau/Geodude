using System;
using System.IO;
using Xunit;

namespace Cpsc370Final.Tests
{
    public class RocketGameTests
    {
        [Fact]
        public void PlayerWinsAndCashesOut_BalanceUpdatedCorrectly()
        {
            // Arrange
            var random = new Random(0); // Seeded random for consistent results
            var player = new Player(1000);
            var game = new RocketGame(player, random);

            double initialBalance = player.money; // Player starts with $1000
            double betAmount = 100;

            // Act
            game.PlaceBet(betAmount);
            // Force the outcome to be safe
            game.Outcome = true;

            // Simulate a winning round
            game.BetAmount = Math.Round(game.BetAmount * 1.1, 2); 
            double expectedBetAfterWin = Math.Round(betAmount * 1.1, 2); 

            // Player decides to cash out
            player.AddMoney(game.BetAmount, 1); 
            game.BetAmount = 0;

            // Assert
            // Since the player's balance did not decrease when placing the bet,
            // the final balance is the initial balance plus the winnings
            Assert.Equal(initialBalance + expectedBetAfterWin - betAmount, player.money); 
            Assert.Equal(0, game.BetAmount);
        }
    }
}
