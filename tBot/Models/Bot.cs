using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using System.Threading.Tasks;
using tBot.Models.Commands;

namespace tBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands { get => commandsList.AsReadOnly(); }

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }
            else
            {
                commandsList = new List<Command>();
                commandsList.Add(new HelloCommand());
                //TODO: Add more commands..

                client = new TelegramBotClient(AppSettings.Key);
                var hook = string.Format(AppSettings.Url, "api/message/update");
                await client.SetWebhookAsync(hook);
                return client;
            }

        }
    }
}