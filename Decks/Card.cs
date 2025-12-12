using System;
using System.Collections.Generic;
using System.Text;

namespace Cardagin.Decks
{
    public abstract class Card
    {
        public virtual string GetCardName()
        {
            return "Card Rank Suit Combo not valid";
        }
    }

    public class StandardCard : Card
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }
        public StandardCard(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string GetCardName()
        {
            return $"{Rank} of {Suit}s";
        }
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
