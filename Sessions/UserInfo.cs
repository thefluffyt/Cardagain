using Cardagin.Decks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace Cardagin.Sessions
{
    public class UserInfo
    {
        public DiscordUser User { get; set; }
        public Dictionary<DiscordChannel, Deck> Decks = new Dictionary<DiscordChannel, Deck>();

        public UserInfo(CommandContext ctx)
        {
            User = ctx.User;
            Decks.Add(ctx.Channel, new EmptyDeck());
        }
    }
}
