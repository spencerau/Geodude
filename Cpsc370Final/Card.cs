namespace Cpsc370Final;

public class Card
{
    /* Constants for suits and face cards */
    public const int HEARTS = 0;
    public const int SPADES = 1;
    public const int CLUBS = 2;
    public const int DIAMONDS = 3;

    public const int JACK = 11;
    public const int QUEEN = 12;
    public const int KING = 13;
    public const int ACE = 14;

    private int m_cardSuit;
    private int m_cardValue;

    /* Default Constructor */
    public Card()
    {
        m_cardSuit = SPADES;
        m_cardValue = ACE;
    }

    /* Overloaded Constructor */
    public Card(int value, int suit)
    {
        m_cardValue = value;
        m_cardSuit = suit;
    }

    /* Copy Constructor */
    public Card(Card aCard)
    {
        this.m_cardSuit = aCard.GetSuit();
        this.m_cardValue = aCard.GetValue();
    }

    /* ToString Method */
    public override string ToString()
    {
        string s = m_cardValue switch
        {
            2 => "Two",
            3 => "Three",
            4 => "Four",
            5 => "Five",
            6 => "Six",
            7 => "Seven",
            8 => "Eight",
            9 => "Nine",
            10 => "Ten",
            11 => "Jack",
            12 => "Queen",
            13 => "King",
            14 => "Ace",
            _ => "Unknown"
        };

        s += m_cardSuit switch
        {
            HEARTS => " of Hearts",
            SPADES => " of Spades",
            CLUBS => " of Clubs",
            DIAMONDS => " of Diamonds",
            _ => " of Unknown Suit"
        };

        return s;
    }

    /* Equals Method */
    public override bool Equals(object? obj)
    {
        if (obj is not Card aCard)
        {
            return false;
        }

        return this.m_cardSuit == aCard.GetSuit() && this.m_cardValue == aCard.GetValue();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(m_cardSuit, m_cardValue);
    }

    /* Getters and Setters */
    public void SetSuit(int newSuit) => m_cardSuit = newSuit;
    public void SetValue(int newValue) => m_cardValue = newValue;
    public int GetSuit() => m_cardSuit;
    public int GetValue() => m_cardValue;
}
