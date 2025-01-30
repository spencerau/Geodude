namespace Cpsc370Final;

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
            if (value == 14) // Ace, needs special handling
            {
                aceCount++;
                value = 11; // Initially count Ace as 11
            }
            else if (value > 10) value = 10; // Face cards (Jack, Queen, King) are worth 10

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

    public override string ToString()
    {
        string hand = "";
        foreach (Card card in cards)
        {
            hand += card + " ";
        }
        return hand;
    }
}