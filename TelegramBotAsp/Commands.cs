using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRTelegramBot.Attributes;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PRTelegram
{
    #region
    public class Commands
    {
        [ReplyMenuHandler("Test", "Fu", "qq")]
        public static async Task Example(ITelegramBotClient botClient, Update update)
        {
            var message = "Hello world";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }

        [ReplyMenuHandler("1")]
        public static async Task ExampleGPT(ITelegramBotClient botClient, Update update)
        {
            var message = "Program.Get";
            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }
    }
    #endregion
}
