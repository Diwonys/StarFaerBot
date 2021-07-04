using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.DataBase;

namespace TelegramBotApp.Models.Commands.Admin
{
    class NotificationUsers : Command
    {
        public override string Name => "publish_data_now";
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            AdminSettings admin = new AdminSettings();

            if (admin.IsAdmin(chatId.ToString()))
            {
                AdminDB data = new AdminDB();
                List<string> usersId = data.GetUsersId();
                string info = GetTextXML("info_to_publish", "setup_data_for_publish.xml");
                
                foreach (var item in usersId)
                {
                    ChatId id = new ChatId((long)Convert.ToInt32(item));
                    await client.SendTextMessageAsync(id, info);
                }
                await client.SendTextMessageAsync(chatId, "Все пользователи оповещены");
            }
        }
    }
}