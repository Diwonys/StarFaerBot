using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.DataBase;

namespace TelegramBotApp.Models.Commands.Admin
{
    public class DeleteAdmin : Command
    {
        public override string Name => "delete_admin";
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            AdminSettings admin = new AdminSettings();

            if (admin.IsAdmin(chatId.ToString()))
            {
                string[] user_id = message.Text.Split(new char[] { ':' });
                AdminDB dataAdmin = new AdminDB();
                await dataAdmin.DeleteAdmin(chatId.ToString(), user_id[1]);
                await client.SendTextMessageAsync(chatId, $"admin with user_id {user_id[1]} deleted");
            }
        }
    }
}
