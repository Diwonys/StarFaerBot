using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.DataBase;

namespace TelegramBotApp.Models.Commands.Admin
{
    class GetAdmins : Command
    {
        public override string Name => "get_admins";
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            AdminSettings admin = new AdminSettings();

            if (admin.IsAdmin(chatId.ToString()))
            {
                AdminDB dataAdmin = new AdminDB();
                await client.SendTextMessageAsync(chatId, dataAdmin.SendAdmins());
            }
        }
    }
}

