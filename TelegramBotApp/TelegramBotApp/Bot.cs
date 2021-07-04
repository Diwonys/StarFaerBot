using System;
using System.Collections.Generic;
using Telegram.Bot;
using TelegramBotApp.Models.Commands;
using TelegramBotApp.Controllers;
using TelegramBotApp.Models;
using TelegramBotApp.Models.Commands.Admin;
using TelegramBotApp.Models.Commands.Payments;

namespace TelegramBotApp
{
    class Bot
    {
        private static List<Command> commandsList;
        
        public static TelegramBotClient client;
        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();
        
        public Bot()
        {
            
            commandsList = new List<Command>();
            
            commandsList.Add(new StartCommand()); 
            commandsList.Add(new InformationCommand()); 
            commandsList.Add(new ServicesCommand());    //Какие услуги вы предоставляете ?
            commandsList.Add(new BetterCommand());      //Чем вы лучше других ?
            commandsList.Add(new ProfitCommand());      //Как я могу с тобой заработать? 
            commandsList.Add(new PaysQuickCommand());   //Как быстр окупается вип-чат? 
            commandsList.Add(new WarrantyCommand());    //Что делать, если не зайдёт ставка? Какие гарантии ?
            commandsList.Add(new WhySelling());         //Почему мы продаём прогнозы ?
            commandsList.Add(new ReviewsCommmand());    //Какие у вас есть отзывы?  
            commandsList.Add(new StatisticsCommand());  //Какая проходимость ваших прогнозов?
            commandsList.Add(new FreeCommand());        //Могу ли я получить бесплатный прогноз?
            commandsList.Add(new TestPayCommand()); 


            //-------------Admins commands---------------------
            commandsList.Add(new SetupInfoPublish());
            commandsList.Add(new SetupInfoPay());

            commandsList.Add(new NotificationUsers());
            commandsList.Add(new NotificatonUsersTime());
            
            commandsList.Add(new GetDatabase());

            commandsList.Add(new GetAdmins());
            commandsList.Add(new SetAdmin());
            commandsList.Add(new DeleteAdmin());

            client = new TelegramBotClient(AppSettings.Key);
        }

        public void Get()
        {
            client.OnMessage += MessageController.BotOnMessageReceived;
            client.OnMessageEdited += MessageController.BotOnMessageReceived;
            client.OnCallbackQuery += MessageController.Client_OnCallbackQuery;
                         
            client.StartReceiving();

            Console.ReadLine();
            client.StopReceiving();
        }

       
    }
}