using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;

namespace TelegramBotApp.Models.Commands
{
    class ServicesCommand : Command
    {
        public override string Name => "services";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(chatId, GetTextXML(Name), replyMarkup: ProfitAction());
            await client.SendTextMessageAsync(chatId, GetTextXML("interest"));
        }
    }
}
