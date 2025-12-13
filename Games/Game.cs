using System;

namespace Cardagin.Games
{
    public abstract class Game
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlayers { get; set; }
        public bool CanHotJoin { get; set; }

        public static Dictionary<string, Game> GameCodes = new Dictionary<string, Game>{
            //{"poker", new PokerGame()},
        };

        public Decks.Deck GameDeck { get; set; }
    }
}
