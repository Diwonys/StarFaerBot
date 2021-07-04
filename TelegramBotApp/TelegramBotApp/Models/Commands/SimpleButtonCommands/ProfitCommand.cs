using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotApp.Models.Commands
{
    class ProfitCommand : Command
    {
        public override string Name => "profit";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, GetTextXML(Name), replyMarkup: ProfitAction());
        }
    }
}
