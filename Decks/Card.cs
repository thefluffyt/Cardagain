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

        public virtual string GetShortCardName()
        {
            return "Card Rank Suit Combo not valid";
        }
    }

    
}
