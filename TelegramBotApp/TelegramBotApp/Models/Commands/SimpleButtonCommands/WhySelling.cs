using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotApp.Models.Commands
{
    class WhySelling : Command
    {
        public override string Name => "why_selling";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            var KeyboardButons = new InlineKeyboardButton[][]
            {
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("Информация", "info")
                },
            };
            var replyMarkup = new InlineKeyboardMarkup(KeyboardButons);

            await client.SendTextMessageAsync(chatId, GetTextXML(Name), replyMarkup: replyMarkup);
        }
    }
}
