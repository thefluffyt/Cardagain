using System;
using System.Collections.Generic;
using System.Text;

namespace Cardagin.Games
{
    public class Blackjack : Game
    {
        public Blackjack()
        {
            Name = "Blackjack";
            Description = "A classic casino card game where players try to get as close to 21 as possible without going over.";
            MinPlayers = 1;
            MaxPlayers = 7;
            CanHotJoin = true;
            GameDeck = new Decks.StandardDeck();
        }
    }
}
