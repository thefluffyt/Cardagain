using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cardagin.Games.Commands
{
    public class GameCommands : BaseCommandModule
    {
        [Command("start")]
        [Description("Starts the game")]
        public async Task Start(CommandContext ctx, string selection)
        {
            await ctx.Channel.SendMessageAsync("Game Started!").ConfigureAwait(false);
        }

        [Command("Add")]
        public async Task Add(CommandContext ctx, int a, int b)
        {
            int sum = a + b;
            await ctx.Channel.SendMessageAsync($"The sum of {a} and {b} is {sum}.").ConfigureAwait(false);
        }
    }
}