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
using TelegramBotAsp.Models;
using TelegramBotAsp.Context;



namespace TelegramBotAsp.Controllers
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
            string Countryid;
            double Probability;

            Console.WriteLine(message);



            //using (PersonContext db = new PersonContext())
            //{
            //    // получаем объекты из бд и выводим на консоль
            //    var users = db.Person.ToList();
            //    Console.WriteLine("Список объектов:");
            //    foreach (Person u in users)
            //    {
            //      Console.WriteLine($"{u.Country}");
            //    }
            //}


            using (HttpClient client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                {
                  { "name", update.Message.Text }
                };
                Console.WriteLine("1");
                string queryString = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
                HttpResponseMessage response = await client.GetAsync($"https://api.nationalize.io/?{queryString}");

                Console.WriteLine("2");
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);

                Person? restoredPerson = JsonSerializer.Deserialize<Person>(responseBody);

                Console.WriteLine("3");
                message = "Страна - " + restoredPerson.Country[0].country_id + ". Вероятность = " + restoredPerson.Country[0].probability.ToString();
                // message = "Страна - " + restoredPerson.country.country_id + ". Вероятность = " + restoredPerson.country.probability.ToString();
                Console.WriteLine(message);

                Countryid = restoredPerson.Country[0].country_id;
                Probability = restoredPerson.Country[0].probability;

            }


            var sendMessage = await PRTelegramBot.Helpers.Message.Send(botClient, update, message);

            using (ApContext db = new())
            {
                if (db.Database.CanConnect())
                {
                    Console.WriteLine("OKi");
                }

            }


            using (PersonContext db = new())
            {
                Console.WriteLine("go");

                db.Database.EnsureCreated();

                Console.WriteLine("go2");


                if (db.Database.CanConnect())
                {
                    Console.WriteLine("OK");
                }

                //  db.Test.Add(new Test { Id = 1, Name = "Re", Description = "Roov" });
                //  db.SaveChanges();

                //  var Tests = db.Test.ToList();

                //foreach (var test in Tests)
                //{
                //    Console.WriteLine($"{test.Id}.{test.Name} - {test.Description}");
                //}

                //добавляем их в бд
                //db.Person.Add(new Person(update.Message.Text, new Country(Countryid, Probability)));

                //db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");


                // получаем объекты из бд и выводим на консоль
                //     var users = db.Person.ToList();
                Console.WriteLine("Список объектов:");
                //foreach (Person u in users)
                //{
                //    Console.WriteLine($"{u.Country}");

            }
        }



    }
}
#endregion

