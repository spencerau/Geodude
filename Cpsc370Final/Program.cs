namespace Cpsc370Final;

class Program
{
    static void Main(string[] args)
    {
        Player gambler = new Player(100.0);
        Console.WriteLine("Welcome to Casino Game!");
        bool exit = false;
        while (!exit)
        {
            CasinoMainMenu.ShowMenu();
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("You chose Rocket Game!");
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

    // this is just an example of how to get the command
    // line arguments so you can use them
    private static void ShowArguments(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine("  Argument " + i +": " + args[i]);
        }
    }
}