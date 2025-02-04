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

await telegram.Start();

#endregion


//app.Run();



#region YaApi


app.Run(async (context) =>
{
    var response = context.Response;
    response.Headers.ContentLanguage = "ru-RU";
    response.Headers.ContentType = "text/plain; charset=utf-8";
    response.Headers.Append("secret-id", "256");    // добавление кастомного заголовка
    await response.WriteAsync("ѕривет METANIT.COM");
});

app.Run();



#endregion



