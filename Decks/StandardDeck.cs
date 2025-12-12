using System;
using System.Collections.Generic;
using System.Text;

namespace Cardagin.Decks
{
    public class StandardDeck : Deck
    {
        public StandardDeck(bool jokers = false)
        {
            foreach (StandardCard.Suit suit in Enum.GetValues(typeof(StandardCard.Suit)))
            {
                foreach (StandardCard.Rank rank in Enum.GetValues(typeof(StandardCard.Rank)))
                {
                    if (rank == StandardCard.Rank.Joker)
                        continue;
                    Cards.Add(new StandardCard(rank, suit));
                }
            }
            // Add two jokers
            if (jokers)
            {
                Cards.Add(new StandardCard(StandardCard.Rank.Joker, StandardCard.Suit.Spade));
                Cards.Add(new StandardCard(StandardCard.Rank.Joker, StandardCard.Suit.Heart));
            }
        }
    }
}
