using System;
using System.Collections.Generic;
using System.Text;

namespace Cardagin.Decks
{
    public abstract class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public void AddDeck(Deck deckToAdd)
        {
            Cards.AddRange(deckToAdd.Cards);
        }

        public void AddCard(Card cardToAdd)
        {
            Cards.Add(cardToAdd);
        }

        public void Shuffle()
        {
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = new Random().Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
    }

    public class EmptyDeck : Deck
    {
        public EmptyDeck()
        {

        }
    }
}
