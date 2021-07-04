using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot.Args;
using System;
namespace TelegramBotApp.Controllers
{
    public class MessageController 
    {
        public async static void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var commands = Bot.Commands;
            var message = messageEventArgs.Message;
            var client = Bot.client;
         
            foreach (var command in commands)
            {
                if (command.Contains(message.Text)  || command.Contains(message.Document))
                {
                    await Task.Run(() =>  command.Execute(message, client));
                    break;
                }
            }
        }

        public async static void Client_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            var commands = Bot.Commands;
            var client = Bot.client;

            foreach (var command in commands)
            {
                if (command.Contains(e.CallbackQuery.Data))
                {
                    await Task.Run(() => command.Execute(e.CallbackQuery.Message, client));
                    break;
                }
            }
        }
    }
}
