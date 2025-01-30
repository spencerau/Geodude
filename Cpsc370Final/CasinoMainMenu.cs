using System;

namespace Cpsc370Final
{
    public class CasinoMainMenu
    {
<<<<<<< Updated upstream
        public static void ShowMenu()
        {
            Console.WriteLine("\n=== Casino Main Menu ===");
            Console.WriteLine("1) Rocket Game");
            Console.WriteLine("2) Roulette");
            Console.WriteLine("3) Blackjack");
            Console.WriteLine("4) Player Information");
            Console.WriteLine("5) Exit");
            Console.Write("Enter choice: ");
=======
        private static int GetInitialChips()
        {
            int numChips;
            string money;

            Console.WriteLine("How much money in chips would you be willing to buy?");
        
            do
            {
                money = Console.ReadLine();

                if (!int.TryParse(money, out numChips) || numChips <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive whole number.");
                }

            } while (!int.TryParse(money, out numChips) || numChips <= 0);

            Console.WriteLine($"You have bought {numChips} chips.");

            return numChips;
        }
        
        public static void ShowMenu()
        {
            Console.WriteLine("Welcome to Casino Game!");
            bool exit = false;
            
            Player player = new Player(GetInitialChips());
            while (!exit)
            {
                Console.WriteLine("\n=== Casino Main Menu ===");
                Console.WriteLine("1) Rocket Game");
                Console.WriteLine("2) Roulette");
                Console.WriteLine("3) Blackjack");
                Console.WriteLine("4) Player Information");
                Console.WriteLine("5) Exit");
                Console.Write("Enter choice: ");
                
                // should we switch this to be an interface or generic so a class like Game that RocketGame, BLackjack, etc
                // implements etc the Game class etc
                // Game Blackjack, etc

                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("You chose Rocket Game!");
                        RocketGame rocketGame = new RocketGame();
                        rocketGame.PlayRocketGame();
                        break;

                    case "2":
                        Console.WriteLine("You chose Roulette!");
                        Roulette roulette = new Roulette();
                        roulette.StartGame();
                        break;

                    case "3":
                        Console.WriteLine("You chose Blackjack!");
                        Blackjack blackjack = new Blackjack();
                        //@TODO implement this function
                        //blackjack.StartGame();
                        break;

                    case "4":
                        Console.WriteLine("Showing Player Information...");
                        player.ShowStatus();
                        break;

                    case "5":
                        Console.WriteLine("Exiting the Casino...");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
>>>>>>> Stashed changes
        }
    }
}