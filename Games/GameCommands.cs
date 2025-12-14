using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Cardagin.Games.Commands
{
    public class GameCommands : BaseCommandModule
    {
        [Command("start")]
        public async Task StartGame(CommandContext ctx, string gameName)
        {
            Game game = new EmptyGame();
            bool isRecognized = true;

            if (Bot.ActiveGames.ContainsKey(ctx.Channel))
            {
                await ctx.Channel.SendMessageAsync("A game is already active in this channel. Please finish the current game before starting a new one.");
            }

            switch (gameName.ToLower())
            {
                case "blackjack":
                    game = new Blackjack();
                    break;
                case "21":
                    game = new Blackjack();
                    break;
                case "bj":
                    game = new Blackjack();
                    break;
                default:
                    await ctx.Channel.SendMessageAsync($"Game '{gameName}' not recognized.");
                    isRecognized = false;
                    return;
            }

            if (isRecognized)
            {
                game.Start(ctx.Channel);
                await ctx.Channel.SendMessageAsync($"Starting a new game of {game.Name}! For the game to begin there must be at least {game.MinPlayers} and at most {game.MaxPlayers}");
            }

            // Placeholder implementation for starting a game
        }

        [Command("start")]
        public async Task StartGame(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Please specify a game to start. Usage: !start <game_name>");
        }

        [Command("join")]
        public async Task JoinGme(CommandContext ctx)
        {
            if (Bot.ActiveGames.ContainsKey(ctx.Channel))
            {
                Game game = Bot.ActiveGames[ctx.Channel];
                if (game.Players.Count >= game.MaxPlayers)
                {
                    await ctx.Channel.SendMessageAsync($"Sorry {ctx.User.Mention}, the game is already full.");
                    return;
                }

                if (game.Players.ContainsKey(ctx.User.Id))
                {
                    await ctx.Channel.SendMessageAsync($"{ctx.User.Mention}, you have already joined the game.");
                    return;
                }

                game.Players.Add(ctx.User.Id, new Sessions.UserInfo(ctx));
                await ctx.Channel.SendMessageAsync($"{ctx.User.Mention} has joined the game! {game.MaxPlayers - game.Players.Count} slot{(game.MaxPlayers - game.Players.Count == 1 ? "" : "s")} left. {(game.MaxPlayers - game.Players.Count <= 0 ? " The game is now full no more players can join!" : "")}");
            } else {
                await ctx.Channel.SendMessageAsync("There is no active game in this channel to join.");
            }
        }

        [Command("leave")]
        public async Task LeaveGame(CommandContext ctx)
        {
            if (Bot.ActiveGames.ContainsKey(ctx.Channel))
            {
                Game game = Bot.ActiveGames[ctx.Channel];
                if (game.Players.ContainsKey(ctx.User.Id))
                {
                    game.Players.Remove(ctx.User.Id);
                    await ctx.Channel.SendMessageAsync($"{ctx.User.Mention} has left the game. {game.Players.Count} player{(game.Players.Count == 1 ? "" : "s")} remaining.");
                } else {
                    await ctx.Channel.SendMessageAsync($"{ctx.User.Mention}, you are not part of the current game.");
                }

                return;
            }

            await ctx.Channel.SendMessageAsync("There is no active game in this channel.");
        }
    }
}