using System;
using System.IO;
using Xunit;

namespace Cpsc370Final.Tests
{
    public class CasinoMainMenuTests
    {
        [Theory]
        [InlineData(
@"1
5
")]
        [InlineData(
@"4
5
")]
        [InlineData(
@"2
3
5
")]
        public void ShowMenu_WhenUserChoosesOptions_WritesExpectedMessages(string fakeInput)
        {
            // Arrange
            var menu = new Cpsc370Final.CasinoMainMenu();
            using var stringReader = new StringReader(fakeInput);
            using var stringWriter = new StringWriter();

            var originalIn = Console.In;
            var originalOut = Console.Out;

            try
            {
                // Redirect Console
                Console.SetIn(stringReader);
                Console.SetOut(stringWriter);

                // Act
                CasinoMainMenu.ShowMenu();

                // Assert
                var output = stringWriter.ToString();
                Assert.Contains("Casino Main Menu", output);
                // You can also assert specific lines, e.g.:
                // If user entered "1", we expect "You chose Rocket Game!"
                // If user entered "4", we expect "Showing Player Information..."
                // For now, we just check that the menu didn't loop infinitely.
            }
            finally
            {
                // Restore Console
                Console.SetIn(originalIn);
                Console.SetOut(originalOut);
            }
        }
    }
}
