using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotApp.Models.Commands
{
    class ReviewsCommmand : Command
    {
        public override string Name => "review";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            var KeyboardButons = new InlineKeyboardButton[][]
            {
                new InlineKeyboardButton[]
                {                        //withURL
                    InlineKeyboardButton.WithCallbackData("Отзывы", "123"),
                    InlineKeyboardButton.WithCallbackData("Информация", "info")
                },
            };
            var replyMarkup = new InlineKeyboardMarkup(KeyboardButons);

            await client.SendTextMessageAsync(chatId, GetTextXML(Name), replyMarkup: replyMarkup);
        }
    }
}
