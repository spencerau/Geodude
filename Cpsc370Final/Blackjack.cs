namespace Cpsc370Final;

using System;
using System.Collections.Generic;

public class Blackjack
{
    private static int playerChips = 1000; // Starting chip count
    private static int currentBet = 0;

    public static void TestDeck()
    {
        while (true) // Loop for replay functionality
        {
            // Display current chip balance
            Console.WriteLine("\nYou have " + playerChips + " chips.");

            // Ask the player for a bet amount
            Console.WriteLine("Enter your bet amount:");
            string betInput = Console.ReadLine();
            if (int.TryParse(betInput, out int bet) && bet > 0 && bet <= playerChips)
            {
                currentBet = bet;
                playerChips -= currentBet; // Deduct the bet from player's chips
                Console.WriteLine("You have bet " + currentBet + " chips.");
            }
            else
            {
                Console.WriteLine("Invalid bet. Please enter a valid amount.");
                continue;
            }

            // Create a new deck
            Deck deck = new Deck();

            // Deal two cards to the player and two cards to the dealer
            Hand playerHand = new Hand();
            Hand dealerHand = new Hand();

            playerHand.AddCard(deck.Deal());
            playerHand.AddCard(deck.Deal());

            dealerHand.AddCard(deck.Deal());
            dealerHand.AddCard(deck.Deal());

            // Print the initial hands
            Console.WriteLine("Player's hand:");
            Console.WriteLine(playerHand);

            Console.WriteLine("\nDealer's hand (one card hidden):");
            Console.WriteLine(dealerHand.GetCard(0));  // Show only one dealer card

            // Player's turn: choose to hit or stand
            string action = "";
            while (action != "stand" && playerHand.GetTotalValue() < 21)
            {
                Console.WriteLine("\nYour hand value: " + playerHand.GetTotalValue());
                Console.WriteLine("Would you like to 'hit' or 'stand'?");
                action = Console.ReadLine().ToLower();

                if (action == "hit")
                {
                    Console.WriteLine("\nPlayer takes a hit...");
                    playerHand.AddCard(deck.Deal());
                    Console.WriteLine(playerHand);
                }
                else if (action != "stand")
                {
                    Console.WriteLine("Invalid choice. Please type 'hit' or 'stand'.");
                }
            }

            // Dealer's turn (dealer hits until reaching 17 or more)
            Console.WriteLine("\nDealer's turn...");
            while (dealerHand.GetTotalValue() < 17)
            {
                dealerHand.AddCard(deck.Deal());
                Console.WriteLine(dealerHand);
            }

            // Determine the winner and calculate payout
            DetermineWinner(playerHand, dealerHand);

            // Ask the player if they want to play again
            Console.WriteLine("\nWould you like to play again? (yes/no)");
            string playAgain = Console.ReadLine().ToLower();

            if (playAgain != "yes")
            {
                Console.WriteLine("Thanks for playing!");
                break; // Exit the loop to end the game
            }

            Console.WriteLine(); // Add a blank line for spacing between rounds
        }
    }

    private static void DetermineWinner(Hand playerHand, Hand dealerHand)
    {
        Console.WriteLine("\nFinal hands:");
        Console.WriteLine($"Player's hand: {playerHand} (Total: {playerHand.GetTotalValue()})");
        Console.WriteLine($"Dealer's hand: {dealerHand} (Total: {dealerHand.GetTotalValue()})");

        int playerTotal = playerHand.GetTotalValue();
        int dealerTotal = dealerHand.GetTotalValue();

        if (playerTotal > 21)
        {
            Console.WriteLine("Player busts! Dealer wins.");
        }
        else if (dealerTotal > 21)
        {
            Console.WriteLine("Dealer busts! Player wins.");
            playerChips += currentBet * 2; // Player wins and gets double the bet
        }
        else if (playerTotal > dealerTotal)
        {
            Console.WriteLine("Player wins!");
            playerChips += currentBet * 2; // Player wins and gets double the bet
        }
        else if (dealerTotal > playerTotal)
        {
            Console.WriteLine("Dealer wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
            playerChips += currentBet; // Player gets their bet back
        }

        Console.WriteLine($"You now have {playerChips} chips.");
    }
}

public class Hand
{
    private List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int GetTotalValue()
    {
        int totalValue = 0;
        int aceCount = 0;

        foreach (Card card in cards)
        {
            int value = card.GetValue();
            if (value > 10) value = 10; // Face cards (Jack, Queen, King) are worth 10

            if (value == 14) // Ace, needs special handling
            {
                aceCount++;
                value = 11; // Initially count Ace as 11
            }

            totalValue += value;
        }

        // Adjust for Ace (if the total exceeds 21, reduce Ace value from 11 to 1)
        while (totalValue > 21 && aceCount > 0)
        {
            totalValue -= 10;
            aceCount--;
        }

        return totalValue;
    }

    public Card GetCard(int index)
    {
        return cards[index];
    }
}
