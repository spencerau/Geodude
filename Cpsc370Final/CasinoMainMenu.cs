using System;

namespace Cpsc370Final
{
    public class CasinoMainMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("Welcome to Casino Game!");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== Casino Main Menu ===");
                Console.WriteLine("1) Rocket Game");
                Console.WriteLine("2) Roulette");
                Console.WriteLine("3) Blackjack");
                Console.WriteLine("4) Player Information");
                Console.WriteLine("5) Exit");
                Console.Write("Enter choice: ");

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
                        break;

                    case "3":
                        Console.WriteLine("You chose Blackjack!");
                        break;

                    case "4":
                        Console.WriteLine("Showing Player Information...");
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
        }
    }
}
