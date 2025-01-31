using System;

namespace Cpsc370Final
{
    public class CasinoMainMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n=== Casino Main Menu ===");
            Console.WriteLine("1) Rocket Game");
            Console.WriteLine("2) Roulette");
            Console.WriteLine("3) Blackjack");
            Console.WriteLine("4) Player Information");
            Console.WriteLine("5) Exit");
            Console.Write("Enter choice: ");
        }
    }
}