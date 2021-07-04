using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.DataBase;
using System;
namespace TelegramBotApp.Models.Commands
{
    class StartCommand : Command
    {
        public override string Name => "start";
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            UsersDB data = new UsersDB();
            if (!data.SubscriberExists(chatId.ToString()))
            {
                await data.AddSubscriber(chatId.ToString(), message.Chat.FirstName);
            }
            await client.SendTextMessageAsync(chatId, GetTextXML(Name));
            await client.SendTextMessageAsync(chatId, GetTextXML("help"), replyMarkup: ShowInfoKB());
        }
    }
}
