using Telegram.Bot.Types;
using Telegram.Bot;
using System.Xml;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotApp.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void Execute(Message message, TelegramBotClient client);
        public bool Contains(Document d)
        {
            if (d != null)
            {
                return d.FileName.Contains(this.Name);
            }
            return false;
        }
        public bool Contains(string command)
        {
            if (command != null)
            {
                return command.Contains(this.Name)/*&& command.Contains(AppSettings.Name)*/;
            }
            return false;
        }

        public string GetTextXML(string name)
        {
            XmlDocument xDoc = new XmlDocument(); 
            xDoc.Load((AppSettings.PathResources+"DescriptionText.xml"));
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == name)
                    {
                        return childnode.InnerText;
                    }
                }
            }
            return "";
        }
        public static string GetTextXML(string name, string fileName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load((AppSettings.PathResources + fileName));
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == name)
                    {
                        return childnode.InnerText;
                    }
                }
            }
            return "";
        }
        public InlineKeyboardMarkup ProfitAction()
        {
            var KeyboardButons = new InlineKeyboardButton[][]
            {
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithUrl("Платный ординар", "https://telegra.ph/InfoBET-Platnyj-ordinar-10-09")
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithUrl("Платный экспресс ", "https://telegra.ph/InfoBET-Platnyj-ehkspress-10-09")
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithUrl("Подписка на VIP Chat", "https://telegra.ph/InfoBET-Vip-Chat-10-09")
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithUrl("Марафон", "https://telegra.ph/InfoBET-Marafon-10-13")
                },
                new InlineKeyboardButton[]
                {
                    InlineKeyboardButton.WithCallbackData("Информация", "info")
                }
            };
            var replyMarkup = new InlineKeyboardMarkup(KeyboardButons);
            return replyMarkup;
        }
        public InlineKeyboardMarkup ShowInfoKB()
        {
            var KeyboardButons = new InlineKeyboardButton[][]
            {
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Какие услуги вы предоставляете?", "services")
                  },
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Как я могу с тобой заработать?", "profit")
                  },
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Как быстр окупается вип-чат? ", "quick_pay")
                  },
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Могу ли я получить бесплатный прогноз?", "free")
                  },
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Что делать, если не зайдёт ставка? Какие гарантии ?", "warranty")
                  },
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Какая проходимость ваших прогнозов?", "statistics")
                  },
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Почему мы продаём прогнозы ?", "why_selling")
                  },
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Чем вы лучше других?", "better")
                  },
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Какие у вас есть отзывы?", "review")
                  }
            };
            var replyMarkup = new InlineKeyboardMarkup(KeyboardButons);
            return replyMarkup;
        }
    }
}
