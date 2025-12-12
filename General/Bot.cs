using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Cardagin.Config;

namespace Cardagin
{
    public class Bot
    {
        public DiscordClient? Client { get; private set; }
        public CommandsNextExtension? Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
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
                AutoReconnect = true
            };

            Client = new DiscordClient(config);

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = true,

            };

            Commands = Client.UseCommandsNext(commandsConfig);

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
