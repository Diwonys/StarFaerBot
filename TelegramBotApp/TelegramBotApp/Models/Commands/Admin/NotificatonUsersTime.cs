using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;
using System.Collections.Generic;
using TelegramBotApp.Models.DataBase;

namespace TelegramBotApp.Models.Commands.Admin
{
    public class NotificatonUsersTime : Command
    {
        public override string Name => "publish_data_time";
        private static bool quit;
        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            AdminSettings admin = new AdminSettings();

            if (admin.IsAdmin(chatId.ToString()))
            {
                string[] date = message.Text.Split(new char[] { ':' });
                await client.SendTextMessageAsync(chatId, 
                    $"пользователи будут оповещены дата {date[1]}:{date[2]} время {date[3]}:{date[4]}");
                quit = false;
                await NotifyTime(date, chatId);
            }
        }
        private static int GetDeltaTime(string[] date)
        {
            DateTime dt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now);
            TimeSpan tsIntervalNow = dt.Subtract(DateTime.Now);
            int iSecondsNow = Convert.ToInt32(tsIntervalNow.TotalSeconds);

            DateTime datePublish = new DateTime(DateTime.Now.Year, 
                Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(date[3]), Convert.ToInt32(date[4]), 00);
            TimeSpan tsIntervalPublish = dt.Subtract(datePublish);
            int iSecondsPublish = Convert.ToInt32(tsIntervalPublish.TotalSeconds);

            return Math.Abs(iSecondsPublish - iSecondsNow) * 1000;
        }
        private async Task NotifyTime(string[] date, long adminId)
        {
            int interval = GetDeltaTime(date);
            TimerCallback timerCallback = new TimerCallback(Notify);
            Timer timer = new Timer(timerCallback, adminId, interval, 0);
            while (!quit) { }
        }
        private async static void Notify(object obj)
        {
            AdminDB data = new AdminDB();
            List<string> usersId = data.GetUsersId();
            string info = GetTextXML("info_to_publish", "setup_data_for_publish.xml");

            foreach (var item in usersId)
            {
                ChatId id = new ChatId((long)Convert.ToInt32(item));
                await Bot.client.SendTextMessageAsync(id, info);
            }
            await Bot.client.SendTextMessageAsync((long)obj, "Все пользователи были оповещены");
            quit = true;
        }
    }
}

