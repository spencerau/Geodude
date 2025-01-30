using System;
using System.Collections.Generic;

namespace Cpsc370Final;

public class Deck
{
    private List<Card> m_deck = new List<Card>(); // List that holds unique cards
    private const int DECKSIZE = 52; // Standard deck size
    private Random r = new Random();

    /* Default Constructor */
    public Deck()
    {
        for (int i = 0; i < DECKSIZE; i++)
        {
            int value = (i % 13) + 2; // Value ranges from 2 to 14 (Ace)
            int suit = i / 13; // 4 suits
            Card card = new Card(value, suit);
            m_deck.Add(card);
        }
    }

    /* Copy Constructor */
    public Deck(Deck aDeck)
    {
        foreach (Card card in aDeck.GetDeckList())
        {
            m_deck.Add(new Card(card)); // Copy each card
        }
    }

    /* ToString Method */
    public override string ToString()
    {
        return string.Join("\n", m_deck); // Prints each card on a new line
    }

    /* Returns the number of cards in the deck */
    public int Size() => m_deck.Count;

    /* Deals (removes and returns) a random card from the deck */
    public Card Deal()
    {
        if (m_deck.Count == 0)
        {
            throw new InvalidOperationException("Cannot deal from an empty deck.");
        }

        int randomIndex = r.Next(m_deck.Count);
        Card drawnCard = m_deck[randomIndex];
        m_deck.RemoveAt(randomIndex);
        return drawnCard;
    }

    /* Returns the current list of cards in the deck */
    public List<Card> GetDeckList() => new List<Card>(m_deck);

    /* Sets a new deck from a provided list of cards */
    public void SetNewDeck(List<Card> newDeck)
    {
        m_deck = new List<Card>(newDeck);
    }
}