using PRTelegramBot.Core;
using PRTelegramBot.Extensions;
using PRTelegramBot.Models.EventsArgs;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;




#region TelegramBot
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddBotHandlers();


var app = builder.Build();

var serviceProvider = app.Services.GetService<IServiceProvider>();

var telegram = new PRBotBuilder("7746352989:AAEBtmm9V4XKU_c35x5qsJH8viI_6mXzndU")
                    .SetServiceProvider(serviceProvider)
                    .Build();

async Task PrBotInstance_OnLogError(ErrorLogEventArgs e)
{
    Console.WriteLine(e.Exception.ToString());
}

async Task PrBotInstance_OnLogCommon(CommonLogEventArgs e)
{
    Console.WriteLine(e.Message);
}

telegram.Events.OnCommonLog += PrBotInstance_OnLogCommon;
telegram.Events.OnErrorLog += PrBotInstance_OnLogError;
#endregion


await telegram.Start();
app.Run();
Console.WriteLine("response");


#region YaApi

partial class Program {


    static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        var apiKey = "t1.9euelZqYyo_PxpnMl8mKm87IjpnGmu3rnpWampiMkpKbm43OypGXkouWmZDl8_dEPQdD-e9HG3Rc_t3z9wRsBEP570cbdFz-zef1656Vms7Px8eYiZuQjIrOzpqTlpab7_zF656Vms7Px8eYiZuQjIrOzpqTlpab.83qQ2qFG7yNAmyCSwpSNXgFGA7a5SqiIemXq3WiEz1JYqo4OrknFjrUZ_cQwsNDEXJVYhKZbMy6Gl1TVL_PNDg\r\n"; // Замените на ваш API-ключ
        var prompt = "{\r\n  \"modelUri\": \"gpt://enpkniiv4vodfarhi9uo/yandexgpt-lite\",\r\n  \"completionOptions\": {\r\n    \"stream\": false,\r\n    \"temperature\": 0.6,\r\n    \"maxTokens\": \"2000\"\r\n  },\r\n  \"messages\": [\r\n    {\r\n      \"role\": \"system\",\r\n      \"text\": \"Найди ошибки в тексте и исправь их\"\r\n    },\r\n    {\r\n      \"role\": \"user\",\r\n      \"text\": \"Ламинат подойдет для укладке на кухне или в детской комнате – он не боиться влаги и механических повреждений благодаря защитному слою из облицованных меламиновых пленок толщиной 0,2 мм и обработанным воском замкам.\"\r\n    }\r\n  ]\r\n}";

        var response = await GetYagptResponse(apiKey, prompt);
        Console.WriteLine(response);
    }

    static async Task<string> GetYagptResponse(string apiKey, string prompt)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var requestBody = new
        {
            prompt = prompt,
            max_tokens = 100 // Укажите необходимое количество токенов
        };

        var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://api.yagpt.com/v1/complete", content);

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
        else
        {
            throw new Exception($"Ошибка: {response.StatusCode}");
        }
    }
}




#endregion







