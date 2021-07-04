#define Test
//#define Docker
using System;
using System.Collections.Generic;
using System.Text;


namespace TelegramBotApp
{
    public class AppSettings
    {
        
        #if DEBUG
            #if Docker
                public static string PathResources { get; set; } = @"Resources/";
            #else
                public static string PathResources { get; set; } = @"D:\Telegram_bots\TelegramBot4.0\TelegramBotApp4.0\TelegramBotApp\TelegramBotApp\Resources\";
            #endif
        #else
                public static string PathResources { get; set; } = @"/app/TelegramBotApp/Resources/";
        #endif

        public static string Name { get; set; } = "infobet_bot";
        #if Test
        public static string Key { get; set; } = "1175421180:AAFKHLekGFphZLXl_QFr_7W7kOdyWo-8W1A";
        #else
            public static string Key { get; set; } = "1325257494:AAFgV0s6j5IK4JWcydT-0Eqkii2KW063eAk";
        #endif
    }
}
