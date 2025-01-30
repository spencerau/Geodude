using System;

namespace Cpsc370Final
{
    public class RocketGame
    {
        private Random _random = new Random();

        // Tracking player's bet and guess
        public double BetAmount { get; private set; }

        public string? PlayerGuess { get; private set; } // "go" or "not go"
        public bool Outcome { get; set; }        // true = rocket safe, false = rocket fails

        // TEMPORARY until we have a Player or Bank class
        // later remove this and reference actual Player/Bank classes.
        public double TemporaryBalance { get; private set; } = 1000.0; // example starting balance

        // Place a bet
        public void PlaceBet(double bet)
        {
            // in the future, you'd call Bank/Player methods to check if bet is valid
            BetAmount = bet;

            // deduct from temporary balance later remove once we have a Bank class
            TemporaryBalance -= BetAmount;
        }

        // lets the player submit guesses before the round starts.
        public void InputGuesses(string guess)
        {
            guess = guess.ToLower();
            if (guess != "go" && guess != "not go")
                throw new ArgumentException("Invalid guess. Allowed values: 'go' or 'not go'.");
            PlayerGuess = guess;
        }

        // randomly determines the outcome for the round with a 90% chance of survival
        public void GenerateOutcome()
        {
            // 90% chance rocket is safe
            Outcome = (_random.NextDouble() < 0.90);
        }

        // compares player guesses with the generated outcome
        public bool CheckWin()
        {
            if (PlayerGuess == null)
                throw new InvalidOperationException("Guess not provided yet!");

            // If rocket is safe && guess is "go" => win
            if (Outcome && PlayerGuess == "go") return true;
            // If rocket fails && guess is "not go" => win
            if (!Outcome && PlayerGuess == "not go") return true;
            return false;
        }

        // shows whether the player won or lost + communicates with the Bank in the future
        // returns how much the player won (0 if lost)
        public double DisplayResult()
        {
            bool won = CheckWin();
            if (won)
            {
                // payoff is 1.1x bet
                double winnings = BetAmount * 1.1;
                Console.WriteLine($"You won {winnings}!");

                // in the future add to bank balance
                // for now, add to temporary placeholder
                TemporaryBalance += winnings;

                return winnings;
            }
            else
            {
                Console.WriteLine("You lost your bet!");
                return 0.0;
            }
        }

        // gives player an option to start a new round after results are displayed
        public void RestartGame()
        {
            BetAmount = 0;
            PlayerGuess = null;
            Outcome = false;
        }

        /// PlayRocketGame: This method runs the "loop" logic, 
        /// prompting the user for bet and guess until they exit or run out of money.
        public void PlayRocketGame()
        {
            bool keepPlaying = true;
            Console.WriteLine("Welcome to the Rocket Game!");

            while (keepPlaying && TemporaryBalance > 0)
            {
                // Prompt for bet
                Console.WriteLine($"Current Balance: {TemporaryBalance}");
                Console.Write("Enter bet (or 0 to exit): ");
                string? betText = Console.ReadLine();
                if (!double.TryParse(betText, out double bet) || bet < 0)
                {
                    Console.WriteLine("Invalid bet.");
                    continue;
                }

                if (bet == 0)
                {
                    Console.WriteLine("Exiting Rocket Game...");
                    break;
                }

                PlaceBet(bet);

                // Prompt for guess ("go" or "not go")
                Console.Write("Guess 'go' or 'not go': ");
                string? guessText = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(guessText))
                {
                    Console.WriteLine("Invalid guess.");
                    continue;
                }

                try
                {
                    InputGuesses(guessText);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                // Generate rocket outcome, show result
                GenerateOutcome();
                double roundWinnings = DisplayResult();
                if (roundWinnings > 0)
                {
                    Console.WriteLine($"You won {roundWinnings}!");
                }
                else
                {
                    Console.WriteLine("You lost your bet!");
                }

                // Check if we can keep playing
                if (TemporaryBalance <= 0)
                {
                    Console.WriteLine("No more funds! Game over!");
                    break;
                }

                // Ask to continue or exit
                Console.Write("Play another round? (y/n): ");
                string? response = Console.ReadLine();
                if (response?.ToLower() == "n")
                {
                    keepPlaying = false;
                }
                else
                {
                    RestartGame();
                }
            }

            Console.WriteLine("Thanks for playing Rocket Game!");
        }
    }
}