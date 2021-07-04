using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotApp.Models.Commands
{
    class InformationCommand : Command
    {
        public override string Name => "info";
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, GetTextXML(Name), replyMarkup: ShowInfoKB());
        }
    }
}
