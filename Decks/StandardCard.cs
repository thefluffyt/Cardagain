using System;
using System.Collections.Generic;
using System.Text;

namespace Cardagin.Decks
{
    public class StandardCard : Card
    {
        public Rank rank { get; private set; }
        public Suit suit { get; private set; }
        private Dictionary<Suit, string> suitSymbols = new Dictionary<Suit, string>
        {
            { Suit.Club, "♣" },
            { Suit.Diamond, "♦" },
            { Suit.Heart, "♥" },
            { Suit.Spade, "♠" }
        };

        public StandardCard()
        {
            rank = Rank.Joker;
            suit = Suit.Club;
        }

        public StandardCard(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public override string GetCardName()
        {
            return $"{rank} of {suit}s";
        }

        public override string GetShortCardName()
        {
            return $"{rank} {suitSymbols[suit]}";
        }

        public enum Rank
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace,
            Joker
        }

        public enum Suit
        {
            Club,
            Diamond,
            Heart,
            Spade
        }
    }
}
