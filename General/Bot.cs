using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Cardagin.Config;
using Cardagin.Games;
using DSharpPlus.Entities;

namespace Cardagin
{
    public class Bot
    {
        public DiscordClient? Client { get; private set; }
        public CommandsNextExtension? Commands { get; private set; }

        public static Dictionary<DiscordChannel, Game> ActiveGames = new Dictionary<DiscordChannel, Game>();

        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("C:\\Projects\\Cardagain\\Config\\config.json"))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = await sr.ReadToEndAsync().ConfigureAwait(false);
                }
            }

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                Intents = DiscordIntents.MessageContents | DiscordIntents.GuildMessages | DiscordIntents.DirectMessages
            };

            Client = new DiscordClient(config);

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = true,
                DmHelp = true,
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<Games.Commands.GameCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
