using Telegram.Bot;
using Telegram.Bot.Types;
using System.IO;
using System.Threading.Tasks;

namespace TelegramBotApp.Models.Commands.Admin
{
    public class SetupInfoPay : Command
    {
        public override string Name => "setup_data_for_pay.xml";
        private async Task SaveFileAsync(Message message, TelegramBotClient bot)
        {
            var FileId = message.Document.FileId;
            var fileInfo = await bot.GetFileAsync(FileId);
            string strFilePath = AppSettings.PathResources + Name;
            FileStream saveStream = System.IO.File.Open(strFilePath, FileMode.Create, FileAccess.ReadWrite);
            await bot.DownloadFileAsync(fileInfo.FilePath, saveStream);
            saveStream.Dispose();
        }

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            AdminSettings admin = new AdminSettings();

            if (admin.IsAdmin(chatId.ToString()))
            {
                await SaveFileAsync(message, Bot.client);
                await client.SendTextMessageAsync(chatId, "File " + Name + "loaded");
            }
        }
    }
}
