using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Payments;

namespace TelegramBotApp.Models.Commands.Payments
{
    class TestPayCommand : Command
    {
        public override string Name => "_test_pay";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            

            await client.SendTextMessageAsync(chatId, "тест оплаты");
        }
    }
}
