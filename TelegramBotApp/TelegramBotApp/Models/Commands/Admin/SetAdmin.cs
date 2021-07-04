using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotApp.Models.DataBase;

namespace TelegramBotApp.Models.Commands.Admin
{
    class SetAdmin : Command
    {
        public override string Name => "set_admin";
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            AdminSettings admin = new AdminSettings();

            if (admin.IsAdmin(chatId.ToString()))
            {
                string[] user_id = message.Text.Split(new char[] {':'} );
                AdminDB dataAdmin = new AdminDB();
                await dataAdmin.AddAdmin(user_id[1],user_id[2]);
                await client.SendTextMessageAsync(chatId, $"admin user_id:{user_id[1]} name:{user_id[2]} added");
            }
        }
    }
}
