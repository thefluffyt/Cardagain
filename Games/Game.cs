using System;

namespace Cardagain.Games
{
    public abstract class Game
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlayers { get; set; }

        public static Dictionary<string, Game> GameCodes = new Dictionary<string, Game>{
            //{"poker", new PokerGame()},
        };
    }
}
