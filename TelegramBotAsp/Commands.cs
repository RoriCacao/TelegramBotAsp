using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PRTelegramBot.Attributes;
using PRTelegramBot.Models.Enums;
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

        [ReplyMenuHandler(CommandComparison.Contains, "")]
        public static async Task ExampleApi(ITelegramBotClient botClient, Update update)
        {
            var message = "ProgramApi";

            using (HttpClient client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                {
                  { "name", update.Message.Text }
                };
                string queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
                HttpResponseMessage response = await client.GetAsync($"https://api.nationalize.io/?{queryString}");

                string responseBody = await response.Content.ReadAsStringAsync();

                Person? restoredPerson = JsonSerializer.Deserialize<Person>(responseBody);

                message = "Страна - " + restoredPerson.country[0].country_id + ". Вероятность = " + restoredPerson.country[0].probability.ToString();
                Console.WriteLine(message);

                Console.WriteLine(message);
            }

            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);
        }
    }
    #endregion

    class Person
    {
        public List<Country> country { get; set; }

        public Person(List<Country> Country)
        {
            country = Country;
        }
    }

     class Country
    {
        public string country_id { get; set; }
        public double probability { get; set; }
    }
}
