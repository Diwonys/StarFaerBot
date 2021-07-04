using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using System.IO;
using System.Threading.Tasks;

namespace TelegramBotApp.Models.Commands.Admin
{
    class GetDatabase : Command
    {
        public override string Name => "get_database";

        private InputOnlineFile GetCopyFile()
        {
            string strFilePath = AppSettings.PathResources + "DataBaseUsers.db";
            string strCopyFilePath = AppSettings.PathResources + "DataBaseUsers_send.db";
            if (System.IO.File.Exists(strCopyFilePath))
            {
                System.IO.File.Delete(strCopyFilePath);
            }
            System.IO.File.Copy(strFilePath, strCopyFilePath);
            FileStream Stream = System.IO.File.Open(strCopyFilePath, FileMode.Open, FileAccess.Read);
            InputOnlineFile file = new InputOnlineFile(Stream);
            return file;
        }

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            AdminSettings admin = new AdminSettings();

            if (admin.IsAdmin(chatId.ToString()))
            {
                await client.SendDocumentAsync(chatId, GetCopyFile(), "database");
            }
        }
    }
}
